using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using UnityEditor;
using JetBrains.Annotations;

public class Dialogiikomunikaty : MonoBehaviour
{
    //Dialog
    public Image DialogPanel;
    public Image CharacterIcon;
    public TextMeshProUGUI CharacterName;
    public TextMeshProUGUI DialogText;
    public CinemachineVirtualCamera Camera;
    CinemachineFramingTransposer framingtransposer;
    public bool DialogActive;





    public void Dialog(string Text, string charactername,Sprite charactericon)
    {
        framingtransposer.m_ScreenY = 0.5f;
        DialogPanel.gameObject.SetActive(true);
        DialogText.text = Text;
        CharacterName.text = charactername;
        CharacterIcon.sprite = charactericon;
        DialogActive = true;
        
        


    }
    public void DialogOff()
    {
        framingtransposer.m_ScreenY = 0.8f;
        DialogPanel.gameObject.SetActive(false);
        DialogActive = false;
    }
    public void Start()
    {
        framingtransposer = Camera.GetCinemachineComponent<CinemachineFramingTransposer>();
        framingtransposer.m_ScreenY = 0.8f;
      
    }


}
