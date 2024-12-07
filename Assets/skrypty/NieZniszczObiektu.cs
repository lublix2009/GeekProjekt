using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieZniszczObiektu : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
