using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OdtworzanieSkryptu : MonoBehaviour
{
    public UnityEvent Skrypt;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           Skrypt?.Invoke();
        }
        
    }
}
