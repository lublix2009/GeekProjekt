using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEditor;

public class Dialog : MonoBehaviour
{

    [Header("Elementy Gui")]
    public TextMeshProUGUI TextDialogu; 
    public GameObject PanelDialogu;
    public TextMeshProUGUI CharacterName;
    public Image CharacterAvatar;

    [Header("Treœci Dialogu")]
    [TextArea(3, 10)]
    public List<string> LinieDialogu;  
    private int AktualnaLinia = 0;  

    [Header("Ustawienia")]
    public float PrêdkoœæPisania = 0.05f;
    public CinemachineVirtualCamera Camera;
    public PlayerMovment playermovment;

    CinemachineFramingTransposer framingtransposer;
    private bool CzyPiszê = false;      
    private Coroutine Obs³ugaAnimacjiTextu;  

    void Start()
    {
        framingtransposer = Camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        framingtransposer.m_ScreenY = 0.8f;
        
        PanelDialogu.SetActive(false);  

    }

    public void StartDialog()
    {
        playermovment.enabled = false;
        PanelDialogu.SetActive(true); 
        AktualnaLinia = 0;         
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (CzyPiszê)
        {
            StopCoroutine(Obs³ugaAnimacjiTextu);
            TextDialogu.text = LinieDialogu[AktualnaLinia];
            CzyPiszê = false;
            return;
        }

        // PrzejdŸ do nastêpnej linii lub zakoñcz dialog
        if (AktualnaLinia < LinieDialogu.Count)
        {
            Obs³ugaAnimacjiTextu = StartCoroutine(PiszText(LinieDialogu[AktualnaLinia]));
            AktualnaLinia++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator PiszText(string line)
    {
        CzyPiszê = true;
        TextDialogu.text = ""; // Wyczyœæ tekst

        foreach (char letter in line.ToCharArray())
        {
            TextDialogu.text += letter; // Dodawaj kolejne litery
            yield return new WaitForSeconds(PrêdkoœæPisania); // Czekaj miêdzy literami
        }

        CzyPiszê = false;
    }

    public void EndDialogue()
    {
        PanelDialogu.SetActive(false);
        playermovment.enabled = true;
        framingtransposer.m_ScreenY = 0.5f;

    }


}
[System.Serializable]
public class LiniaDialogu 
{
    public string CharacterName;
    public Sprite CharacterIcon;
    public string DialogText;
}

