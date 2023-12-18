using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacle;

    private void Awake()
    {

    }

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacle.Length);
            float minTime = 2f;
            float maxTime = 3.5f;
            float randomTime = Random.Range(minTime, maxTime);
            Instantiate(obstacle[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
