using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float szybkoœæPoruszania;
    [SerializeField] private Rigidbody2D rb;
     public new SpriteRenderer renderer;
    public bool graczNaZiemi;
    public LayerMask warstwaZiemi;
    public float si³aSkoku;
    public GameObject punktSprawdzaj¹cyKolizje;
    public float odleg³oœæBySkoczyæ;



    private Vector3 input;


    void Update()
    {
        //poruszanie gracza
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            renderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            renderer.flipX = false;
        }

        input = new Vector3 (inputx, inputy , 0);
        //skok gracza
        if (Input.GetKeyDown(KeyCode.Space) && graczNaZiemi || Input.GetKeyDown(KeyCode.UpArrow) && graczNaZiemi || Input.GetKeyDown(KeyCode.W) && graczNaZiemi)
        {
            rb.velocity = new Vector2(rb.velocity.x, si³aSkoku);
        }


    }

    private void FixedUpdate()
    {
        Vector3 move = input * szybkoœæPoruszania * Time.fixedDeltaTime;
        rb.velocity = new Vector2(move.x, rb.velocity.y);

        graczNaZiemi = Physics2D.OverlapCircle(punktSprawdzaj¹cyKolizje.transform.position, odleg³oœæBySkoczyæ, warstwaZiemi);
    }
}
