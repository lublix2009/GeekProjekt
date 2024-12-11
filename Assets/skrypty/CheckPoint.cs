using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 SaveCheckPointTransform;
    public void WróæNaCheckPoint()
    {
        PlayerTransform.position = SaveCheckPointTransform;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
         SaveCheckPointTransform = collision.transform.position;
        }
       

    }
}
