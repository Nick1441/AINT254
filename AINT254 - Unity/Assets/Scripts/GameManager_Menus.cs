using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Menus : MonoBehaviour
{
    //Default Game Manager, Used On Scenes Main Menu/End Screen. Does Not Conatain Pause Menu Info.
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    //Moving To Game Over Screen.
    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("EndScreen");
    }

    //Moving To Main Menu Screen.
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu_V2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
