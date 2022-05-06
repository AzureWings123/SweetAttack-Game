//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Level1");
    }

     public void StartCredits() 
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void GoBack() 
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void NextLevel() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
