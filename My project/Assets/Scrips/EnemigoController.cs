using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int RUN = 1;
    float jump = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();          
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1, rb.velocity.y);
        //ChangeAnimation(RUN);
        sr.flipX = true;
    }
    private void ChangeAnimation (int a){
        animator.SetInteger("Estado", a);
    }
}
