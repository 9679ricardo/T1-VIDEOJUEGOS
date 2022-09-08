using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugadorCalabaza : MonoBehaviour
{
    //public GameObject JugadorCalabaza;
    public float fuerzaSalto = 200;
    public float velocidad = 100;

    private bool YaGanaste = false;
    private bool EstaSaltando = false;//Para que solo salte una vez
    private bool EstaMuerto = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_QUIETO = 0;//2Saltar
    private const int ANIMATION_CAMINAR = 4;
    private const int ANIMATION_MORIR = 3;
    private int Cont=0;
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

        if (EstaMuerto == false && YaGanaste==false)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && Cont < 2 & EstaSaltando != true)
            {
                Saltar();
                if (Cont == 1)
                {
                    EstaSaltando = true;
                }
                Cont++;
            }



            if (Input.GetKey(KeyCode.RightArrow))//Si presiono la tecla rigtharrow voy a ir hacia la derecha
            {
                if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
                {
                    rb.velocity = new Vector2(velocidad * 2, rb.velocity.y);//velocidad de mi objeto
                    CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                    spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha
                }
                else
                {
                    rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                    CambiarAnimacion(ANIMATION_CAMINAR);//Accion correr 
                    spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C))
                {
                    rb.velocity = new Vector2(-velocidad * 2, rb.velocity.y);//velocidad de mi objeto
                    CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                    spriteRenderer.flipX = true;
                }
                else
                {
                    rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
                    CambiarAnimacion(ANIMATION_CAMINAR);//Accion correr 
                    spriteRenderer.flipX = true;
                }
            }
            else
            {
                CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
                rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
            }
        }
        else if(EstaMuerto==true && YaGanaste==false)
        {
            CambiarAnimacion(ANIMATION_MORIR);//Accion correr 
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);//velocidad de mi objeto
            CambiarAnimacion(ANIMATION_QUIETO);//Accion correr 
        }


    }

    private void Saltar()
    {
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EstaSaltando == true)
        {
            EstaSaltando = false;
            Cont = 0;
        }

        if (collision.gameObject.tag == "Amenaza")
        {
            Destroy(collision.gameObject);//Se va ha destruir mi objeto caja
            EstaMuerto = true;
        }
        if (collision.gameObject.name == "Llave")
        {
            YaGanaste = true;
        }

    }
    //private void FixedUpdate()
    //{
    //    float PosX = JugadorCalabaza.transform.position.x;
    //    float PosY = JugadorCalabaza.transform.position.y;
    //    transform.position = new Vector3(PosX, PosY, transform.position.z);
    //}
}