using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    public Image DialogPanel;
    public Image StartScreen;

    void Start()
    {
        StartScreen.gameObject.SetActive(true);
        DialogPanel.gameObject.SetActive(false);
    }


}
