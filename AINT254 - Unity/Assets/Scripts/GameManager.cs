using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //GAME
    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }



    //MAIN MENU
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    //END MENU
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
