using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string wallTag = "Wall";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            // Ignorar la colisi�n con la pared.
            Physics.IgnoreCollision(GetComponent<Collider>(), other, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            // Restaurar la colisi�n con la pared.
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
        }
    }

    public float velocidad = 5f; // Velocidad de movimiento del enemigo
    public float distanciaVision = 10f; // Distancia de visi�n del enemigo
    public LayerMask capaObstaculos; // Capa de obst�culos en el mundo

    private Transform jugador; // Referencia al transform del jugador
    private Rigidbody rb; // Referencia al componente Rigidbody del enemigo

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;

        if (jugador == null)
        {
            Debug.LogError("No se ha encontrado al jugador en la escena.");
        }
    }

    private void Update()
    {
        // Calcula la direcci�n hacia el jugador
        Vector3 direccionJugador = (jugador.position - transform.position).normalized;

        // Calcula la distancia al jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador est� dentro del rango de visi�n
        if (distanciaAlJugador <= distanciaVision)
        {
            // Mueve al enemigo hacia el jugador
            rb.velocity = direccionJugador * velocidad;

            // Evita obst�culos
            EvitarObstaculos();
        }
        else
        {
            // Si el jugador est� fuera del rango de visi�n, det�n al enemigo
            rb.velocity = Vector3.zero;
        }
    }

    private void EvitarObstaculos()
    {
        // Raycast hacia adelante para detectar obst�culos
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, capaObstaculos))
        {
            // Si se detecta un obst�culo, rota hacia la izquierda
            transform.Rotate(Vector3.up, 45f);
        }
    }
}

