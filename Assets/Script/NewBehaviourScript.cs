using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        // Obtener el componente NavMeshAgent
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Verificar si se encontr� el componente
        if (navMeshAgent == null)
        {
            Debug.LogError("No se encontr� el componente NavMeshAgent. Aseg�rate de adjuntar este script al objeto correcto.");
            enabled = false; // Deshabilitar el script para evitar m�s problemas
            return;
        }

        // Verificar si el objeto tiene un NavMesh
        if (!UnityEngine.AI.NavMesh.SamplePosition(transform.position, out UnityEngine.AI.NavMeshHit hit, 0.1f, UnityEngine.AI.NavMesh.AllAreas))
        {
            Debug.LogError("El objeto no est� en una posici�n v�lida del NavMesh. Ajusta la posici�n inicial del objeto.");
            enabled = false; // Deshabilitar el script para evitar m�s problemas
        }
    }

    void Update()
    {
        // Verificar si el NavMeshAgent est� en una posici�n v�lida
        if (!navMeshAgent.isOnNavMesh)
        {
            Debug.LogWarning("El NavMeshAgent no est� en una posici�n v�lida del NavMesh. Intentando reposicionar.");

            // Intentar encontrar la posici�n m�s cercana en el NavMesh
            if (UnityEngine.AI.NavMesh.SamplePosition(transform.position, out UnityEngine.AI.NavMeshHit hit, 10f, UnityEngine.AI.NavMesh.AllAreas))
            {
                navMeshAgent.Warp(hit.position); // Reposicionar el NavMeshAgent
            }
            else
            {
                Debug.LogError("No se pudo encontrar una posici�n v�lida en el NavMesh. Verifica tu entorno.");
            }
        }

        // Aqu� puedes realizar otras validaciones y ajustes seg�n tus necesidades
    }
}
