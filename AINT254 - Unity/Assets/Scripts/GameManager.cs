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
        Cursor.visible = true;
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
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
