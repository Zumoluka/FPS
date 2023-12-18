using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Bot;
    public List<GameObject> ListaEnemigos;
    float TiempoRestante;
    //public GameObject PlayerPrefab;
    
    void Start()
    {
        ComenzarJuego();
       // Instantiate(PlayerPrefab, new Vector3(1f, 1f, 1f), Quaternion.identity);
    }

   
    void Update()
    {
        if (TiempoRestante == 0) 
        {
            ComenzarJuego();
        }
        if (AllEnemiesDefeated())
        {
            //SceneManager.LoadScene(1);
        }
    }
    
    public IEnumerator ComenzarCronometro(float valorCronometro = 30)
    {
        TiempoRestante = valorCronometro;
        while (TiempoRestante > 0)
        {
            Debug.Log("Restan " + TiempoRestante + " segundos");
            yield return new WaitForSeconds(1.0f);
            TiempoRestante--;
        }
                
    }
    void ComenzarJuego()

    {

        Jugador.transform.position = new Vector3(1f, 1f, 1f);

        foreach (GameObject item in ListaEnemigos)
        {
            Destroy(gameObject);
        }

       // ListaEnemigos.Add(Instantiate(Bot, new Vector3(-11f, 1f, 37f), Quaternion.identity));
        //ListaEnemigos.Add(Instantiate(Bot, new Vector3(-28, 1f, 31f), Quaternion.identity));
        //ListaEnemigos.Add(Instantiate(Bot, new Vector3(-15, 1f, 18f), Quaternion.identity));
        StartCoroutine(ComenzarCronometro(30));
    }
    bool AllEnemiesDefeated()
        {
            foreach (GameObject Bot in ListaEnemigos)
            {
                if (Bot.activeSelf)
                {
                    return false;
                }
            }
            return true;

        }
   

}
