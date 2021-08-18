using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoInicial;
    private Animator anim ;
    private SpriteRenderer sprite;
    void Start()
    // Start is called before the first frame update
    
    {
        posicaoInicial = this.transform.position;
        anim = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX =false;
            Vector3 pos = transform.position;
            pos.x += velocidade;
           transform.position = pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
            Vector3 pos = transform.position;
            pos.x -= velocidade;
            transform.position = pos;
        }
        
        if(Input.GetKey(KeyCode.W)&& tempoPulado <= 0)
        {
           Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
           Vector2 forca = new Vector2 (0f,9f );
           rb.AddForce(forca,ForceMode2D.Impulse);
           tempoPulado = tempoPulo;   
           anim.SetBool("estacorrendo" , true);    
        }
         tempoPulado -= Time.deltaTime;

           if(this.transform.position.y < -14f)
           {
               transform.position = posicaoInicial;
           }
           if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
           {
               anim.SetBool("estacorrendo", true);
           }
           else
           {
               anim.SetBool("estacorrendo" , false);
           }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "espinhos_raivosos")
        {
            this.transform.position = posicaoInicial;
        }
        if(col.gameObject.tag =="chao")
        {
            anim.SetBool("estacorrendo",false);
        }
    }
}
