using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float _spawnertime;
    public float _spawnerTimeRandom;
    private float _spawnerTimer;
    private NavMeshAgent _nav;
    private Vector3 location;
    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Bot");
        location = new Vector3(4, 0, 0);

    }
    private void Update()
    {
        _spawnerTimer -= Time.deltaTime;
        if(_spawnerTimer <= 0f )
        {
            Instantiate(Enemy, location, Quaternion.identity);
            ResetSpawnerTime();
        }
    }
    void ResetSpawnerTime()
    {
        _spawnerTimer = (float)(_spawnertime + Random.Range(0, _spawnerTimeRandom * 100) /100.0 );
    }
}
