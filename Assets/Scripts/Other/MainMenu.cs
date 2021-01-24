using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiadająca za przełączanie scen w MainMenu
/// </summary>


public class MainMenu : MonoBehaviour
{
    public PlayerData player;
    
    void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ContinueGame() {
        player = SaveSystem.LoadPlayer();
        Debug.Log("MainManu.cs lvl: " + player.level);
        SceneManager.LoadScene(player.level);
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void GoToSettingsMenu() {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
   
    public void QuitGame() {
        Application.Quit();
    }
}
