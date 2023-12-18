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
            // Ignorar la colisión con la pared.
            Physics.IgnoreCollision(GetComponent<Collider>(), other, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            // Restaurar la colisión con la pared.
            Physics.IgnoreCollision(GetComponent<Collider>(), other, false);
        }
    }

    public float velocidad = 5f; // Velocidad de movimiento del enemigo
    public float distanciaVision = 10f; // Distancia de visión del enemigo
    public LayerMask capaObstaculos; // Capa de obstáculos en el mundo

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
        // Calcula la dirección hacia el jugador
        Vector3 direccionJugador = (jugador.position - transform.position).normalized;

        // Calcula la distancia al jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está dentro del rango de visión
        if (distanciaAlJugador <= distanciaVision)
        {
            // Mueve al enemigo hacia el jugador
            rb.velocity = direccionJugador * velocidad;

            // Evita obstáculos
            EvitarObstaculos();
        }
        else
        {
            // Si el jugador está fuera del rango de visión, detén al enemigo
            rb.velocity = Vector3.zero;
        }
    }

    private void EvitarObstaculos()
    {
        // Raycast hacia adelante para detectar obstáculos
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, capaObstaculos))
        {
            // Si se detecta un obstáculo, rota hacia la izquierda
            transform.Rotate(Vector3.up, 45f);
        }
    }
}

