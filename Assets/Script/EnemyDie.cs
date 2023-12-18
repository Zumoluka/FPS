using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDie : MonoBehaviour
{
    public float health = 100f;
    public Transform player;

   // private NavMeshAgent navMeshAgent;
    //private bool isFollowingPlayer = true;

    void Start()
    {
        /*navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("El componente NavMeshAgent no se encuentra adjunto al enemigo.");
            enabled = false; 
        }*/
    }

    void Update()
    {
        /*if (isFollowingPlayer)
        {
            FollowPlayer();
        }*/
    }

    void FollowPlayer()
    {
        /*if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }*/
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //isFollowingPlayer = false; 
        OnDie();
    }

    void OnDie()
    {
        
        Debug.Log("El enemigo ha muerto.");
    }
}
