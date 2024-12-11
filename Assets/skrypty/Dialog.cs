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
    public Button Dalejbtn;

    [Header("Tre�ci Dialogu")]
    
    public List<LiniaDialogu> LinieDialogu;  
    private int AktualnaLinia = 0;  

    [Header("Ustawienia")]
    public float Pr�dko��Pisania = 0.05f;
    public CinemachineVirtualCamera Camera;
    public PlayerMovment playermovment;

    CinemachineFramingTransposer framingtransposer;
    private bool CzyPisz� = false;      
    private Coroutine Obs�ugaAnimacjiTextu;
    public Rigidbody2D PlayerRb;

    void Start()
    {
        framingtransposer = Camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        framingtransposer.m_ScreenY = 0.8f;
        
        PanelDialogu.SetActive(false);  

    }

    public void StartDialog()
    {
        RozpocznijOdWybranejLini(0);
    }

    public void ShowNextLine()
    {
        // Przejd� do nast�pnej linii lub zako�cz dialog
        if (AktualnaLinia < LinieDialogu.Count)
        {
             var DaneDialogu = LinieDialogu[AktualnaLinia];

            CharacterName.text = DaneDialogu.CharacterName;
            CharacterAvatar.sprite = DaneDialogu.CharacterIcon;

            Obs�ugaAnimacjiTextu = StartCoroutine(PiszText(DaneDialogu.DialogText));
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
        TextDialogu.text = "";// Wyczy�� tekst
        Dalejbtn.interactable = false;


        foreach (char letter in line.ToCharArray())
        {
            TextDialogu.text += letter; // Dodawaj kolejne litery
            yield return new WaitForSeconds(Pr�dko��Pisania); // Czekaj mi�dzy literami
        }

        CzyPisz� = false;
        Dalejbtn.interactable = true;
    }

    public void RozpocznijOdWybranejLini(int startLine)
    {
        playermovment.enabled = false;
        PlayerRb.velocity = new Vector2(0, 0);
        framingtransposer.m_ScreenY = 0.5f;
        PanelDialogu.SetActive(true);
        AktualnaLinia = startLine;
        ShowNextLine();
    }

    public void EndDialogue()
    {
        PanelDialogu.SetActive(false);
        playermovment.enabled = true;
        framingtransposer.m_ScreenY = 0.8f;

    }


}
[System.Serializable]
public class LiniaDialogu 
{
    public string CharacterName;
    public Sprite CharacterIcon;
    [TextArea(3,10)]public string DialogText;
}

