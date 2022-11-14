using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Enemy2D : MonoBehaviour
{
    public float timeAttackReference;
    private float timeAttack;

    [SerializeField] 
    public Controller2D playerRef;

    [SerializeField]
    Transform posPlayer; //Posicion objetivo

    public int ContLife;


    [SerializeField]
    float distance; //Distancia del player

    public Vector3 puntoInicial; //Reotrnar al punto inicial

    private Animator animator; //Ref del enemigo 

    private SpriteRenderer spriteRenderer; //Ref del enemigo

    public float detectRadius; //Radio desde el player

    public float distanceToPlayer; //Distancia del player


    private void Start()
    {
        timeAttack = timeAttackReference;
        ContLife = 3;
        animator = GetComponent<Animator>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        timeAttack -= Time.deltaTime;
        distance = distanceToPlayer;
        distanceToPlayer = ((Vector2)transform.position - (Vector2)playerRef.transform.position).magnitude;
        // Reemplazar por ontrigger enter si no funciona
       
        if (distanceToPlayer - detectRadius <= playerRef.DetectionRadius )
            animator.SetTrigger("Follow");
        else
            animator.ResetTrigger("Follow");
        if (ContLife <= 0)
        {
            Morir();
        }

    }

    public void Girar(Vector2 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }  
    }
    public void Atacar ()
    {
        timeAttack = timeAttackReference;

        //playerTransform.TakeDamage(5);
        Debug.Log("ATTACK!");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("on trigger");
        if (other.gameObject.CompareTag("tool")&& timeAttack <= 0  ) // 
        {
            ContLife = ContLife - 1;
            Atacar();
        }
        
    }
    public void Morir()
    {
        Destroy(this.gameObject);
    }
}
