
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private string levelToLoad;
    [SerializeField] private Vector2 playerPos;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void Back()
    {
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
