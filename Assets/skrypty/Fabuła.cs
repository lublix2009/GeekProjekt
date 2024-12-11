using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabuła : MonoBehaviour
{
   public  Dialog DialogScript;
    //      Rozdział1
    public bool StartActive;
    public bool Level1Active;
    public bool Level2Active;

    public void Update()
    {
        if (StartActive)
        {
            DialogScript.RozpocznijOdWybranejLini(0);
        }
    }

}
