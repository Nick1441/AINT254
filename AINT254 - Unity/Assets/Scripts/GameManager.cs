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

    //Setting Starting Arguments, Resets Pause Menu. Puts Time Back Incase Restart From Pause Menu.
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        IsGamePaused = false;
        PauseMenu.SetActive(false);
        CM = Camera.GetComponent<CameraMovement>();
        CM.enabled = true;
        W = Weapon.GetComponent<Weapon>();
        Time.timeScale = 1f;
    }
    
    //Checking If Game Is Currently Paused.
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

    //Opens Pause Menu, Freezes Time, Disabeles Movement/Weapon To Prevent User Cheating/Stacking Ammo.
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.SetActive(true);
        IsGamePaused = true;
        Time.timeScale = 0f;
        CM.enabled = false;
        W.enabled = false;
    }

    //Sets Game Back To Default Settings. Hides Cursor. 
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1f;
        CM.enabled = true;
        W.enabled = true;
    }

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

    void Update()
    {
        PauseCheck();
    }
}
