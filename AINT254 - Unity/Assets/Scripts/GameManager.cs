using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseMenu;
    public GameObject Camera;
    public GameObject Weapon;
    private CameraMovement CM;
    private Weapon W;

    //PAUSE MENU
    public void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        CM.enabled = false;
        W.enabled = false;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        CM.enabled = true;
        W.enabled = true;
    }


    public void Start()
    {
        CM = Camera.GetComponent<CameraMovement>();
        W = Weapon.GetComponent<Weapon>();
    }

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
        Time.timeScale = 1f;
    }

    public void Update()
    {
        PauseCheck();
    }
}
