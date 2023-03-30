using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vCorrer = 4;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int SLIDE = 2;
    const int DEAD = 3;
    const int ATTACK = 4;
    const int THROW = 5;
     
    bool estado = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estado == true){
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2(vCorrer, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
        
        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-vCorrer, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
        else if(Input.GetKey(KeyCode.S)){   
                ChangeAnimation(SLIDE);
        }


        
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
        Lazar();
        Atacar();
        Morir();
        }
    }
    private void Lazar(){
        if(Input.GetKey(KeyCode.T)){ 
            rb.velocity = new Vector2(0, 0);  
                ChangeAnimation(THROW);
        }
    }
    private void Atacar(){
        if(Input.GetKey(KeyCode.A)){   
            rb.velocity = new Vector2(0, 0);
            ChangeAnimation(ATTACK);
        } 
    }
    private void Morir(){
        if(Input.GetKey(KeyCode.D)){  
            rb.velocity = new Vector2(0, 0); 
            estado = false;
                ChangeAnimation(DEAD);
        }
    }
    
    private void ChangeAnimation (int a){
        animator.SetInteger("Estado", a);
    }
}
