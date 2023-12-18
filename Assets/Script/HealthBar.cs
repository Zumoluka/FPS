using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Health;
    public float MaxHealth;
    public float ActualHealth;
  
    void Start()
    {
        MaxHealth = ActualHealth;

    }

    
    void Update()
    {
        Health.fillAmount = ActualHealth / MaxHealth;
        if(ActualHealth == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bot"))
        {
            ActualHealth = ActualHealth - 5;
            Debug.Log("Daño");
        }

    }
}
