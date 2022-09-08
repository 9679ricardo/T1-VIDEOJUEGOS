using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorZombieHombre : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 5;
     private bool EstaMuerto = false;

    private bool EstaCaminandoDerecha = false;//Para que solo salte una vez

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        if (EstaCaminandoDerecha == true)
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
            spriteRenderer.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
            spriteRenderer.flipX = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Caja")//Todos los objetos que tengan como tag destruible
        {
            //Destroy(collision.gameObject);//Se va ha destruir mi objeto caja
            if (EstaCaminandoDerecha == true)
            {
                EstaCaminandoDerecha = false;
            }
            else
            {
                EstaCaminandoDerecha = true;
            }
        }
    }
}