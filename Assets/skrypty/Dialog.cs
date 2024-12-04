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

    [Header("Tre�ci Dialogu")]
    [TextArea(3, 10)]
    public List<string> LinieDialogu;  
    private int AktualnaLinia = 0;  

    [Header("Ustawienia")]
    public float Pr�dko��Pisania = 0.05f;
    public CinemachineVirtualCamera Camera;
    public PlayerMovment playermovment;

    CinemachineFramingTransposer framingtransposer;
    private bool CzyPisz� = false;      
    private Coroutine Obs�ugaAnimacjiTextu;  

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
        if (CzyPisz�)
        {
            StopCoroutine(Obs�ugaAnimacjiTextu);
            TextDialogu.text = LinieDialogu[AktualnaLinia];
            CzyPisz� = false;
            return;
        }

        // Przejd� do nast�pnej linii lub zako�cz dialog
        if (AktualnaLinia < LinieDialogu.Count)
        {
            Obs�ugaAnimacjiTextu = StartCoroutine(PiszText(LinieDialogu[AktualnaLinia]));
            AktualnaLinia++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator PiszText(string line)
    {
        CzyPisz� = true;
        TextDialogu.text = ""; // Wyczy�� tekst

        foreach (char letter in line.ToCharArray())
        {
            TextDialogu.text += letter; // Dodawaj kolejne litery
            yield return new WaitForSeconds(Pr�dko��Pisania); // Czekaj mi�dzy literami
        }

        CzyPisz� = false;
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

