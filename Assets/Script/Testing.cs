using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies; // Asegúrate de agregar tus enemigos a esta lista

    void Update()
    {
        if (AllEnemiesDefeated())
        {
            SceneManager.LoadScene(1);
        }
    }

    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}