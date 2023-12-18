using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
public void QuitGame()
{
    Application.Quit();
}
public void EndGame()
    {
        SceneManager.LoadScene("End Game");
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
    }

}
