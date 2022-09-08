using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCajaRebote : MonoBehaviour
{
    public float velocidadX = 7;
    public float velocidadY = 7;

    private bool EstaMuerto = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    
    void Start()
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        rb.velocity = new Vector2(velocidadX, rb.velocity.y);
        rb.velocity = new Vector2(velocidadY, rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LadoDerechaCaja")
        {
            velocidadX = 7;
            velocidadY = -13;
        }
        else if (collision.gameObject.tag == "LadoAbajoCaja")
        {
            velocidadX = 7;
            velocidadY = 7;
        }
        else if (collision.gameObject.tag == "LadoIzquierdaCaja")
        {
            velocidadX = -5;
            velocidadY = 7;
        }
        else if (collision.gameObject.tag == "LadoArribaCaja")
        {
            velocidadX = -2;
            velocidadY = -9;
        }

    }
}

