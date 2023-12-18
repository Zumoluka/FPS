using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Clase : MonoBehaviour
{
    // navegation 
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private float findTargetRate;
    [SerializeField] private float Iniciate;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

     
        InvokeRepeating("FindTarget", Iniciate, findTargetRate);
    }

    
    void Update()
    {
        
    }
    private void FindTarget()
    {
       agent.destination = target.position;

    }


}



