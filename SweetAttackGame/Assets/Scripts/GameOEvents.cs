//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOEvents : MonoBehaviour
{
    // Start is called before the first frame update

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro");
    }

     public void StartCredits() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CreditScene");
    }

    public void GoBack() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
    public void NextLevel() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Upgrades()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("NextLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("UpgradeMenu");
    }
}
