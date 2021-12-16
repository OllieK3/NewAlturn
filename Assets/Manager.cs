using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject gamePanel;

    public string Scenename;

    public void LoadLevel()
    {
        SceneManager.LoadScene(Scenename);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void credits()
    {
        creditsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    
    public void Back()
    {
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}