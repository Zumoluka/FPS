using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyC : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        Destroy(gameObject, delay);
    }
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

       
        rb.freezeRotation = true;
    }
}
