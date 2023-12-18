using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ControlBot : MonoBehaviour
{
    private int hp;
    private GameObject jugador;
    public float Speed;
    public float maxHealth = 100f;
    private float currentHealth;
    private Animator _animation;
    public Transform player;
    //private NavMeshAgent navMeshAgent;
    //private bool isFollowingPlayer = true;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        hp = 100;
        jugador = GameObject.Find("Jugador");
        currentHealth = maxHealth;
         _animation = GetComponent<Animator>();
        /*navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("El componente NavMeshAgent no se encuentra adjunto al enemigo.");
            enabled = false; // Deshabilitar el script para evitar más problemas
        }*/
    }

    public UnityEvent OnDie;

    void Update()
    {
       transform.LookAt(jugador.transform);
       transform.Translate(Speed * Vector3.forward * Time.deltaTime);
        /*if (isFollowingPlayer)
        {
            FollowPlayer();
        }*/
    }
    public void recibirDaño()
    {
        hp = hp - 25;
        //_animation.SetBool("Attack", true);
        if (hp <= 0)
        {
            OnDie.Invoke();
            score.scoreCount += 10;
        }
    }

   /*void FollowPlayer()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }*/

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //isFollowingPlayer = false;
        //navMeshAgent.isStopped = true; 

       
        IsDead();
    }

    void IsDead()
    {
        
        Debug.Log("El enemigo ha muerto.");
    }
   public UnityEvent Atacando;

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.CompareTag("Jugador"))
        {
           
            _animation.SetBool("Attack", true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            recibirDaño();
        }
    }
}

