using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float szybko��Poruszania;
    [SerializeField] private Rigidbody2D rb;
     public new SpriteRenderer renderer;
    public bool graczNaZiemi;
    public LayerMask warstwaZiemi;
    public float si�aSkoku;
    public GameObject punktSprawdzaj�cyKolizje;
    public float odleg�o��BySkoczy�;



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
            rb.velocity = new Vector2(rb.velocity.x, si�aSkoku);
        }


    }

    private void FixedUpdate()
    {
        Vector3 move = input * szybko��Poruszania * Time.fixedDeltaTime;
        rb.velocity = new Vector2(move.x, rb.velocity.y);

        graczNaZiemi = Physics2D.OverlapCircle(punktSprawdzaj�cyKolizje.transform.position, odleg�o��BySkoczy�, warstwaZiemi);
    }
}
