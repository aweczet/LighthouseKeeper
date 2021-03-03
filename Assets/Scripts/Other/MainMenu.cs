using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiadająca za przełączanie scen w MainMenu
/// </summary>


public class MainMenu : MonoBehaviour
{
    private Player _player;
    
    private void Start() {
        SetUpCursor();
        _player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
    }

    private void SetUpCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ContinueGame() {
        SceneManager.LoadScene(_player.level);
    }

    // instead of scene index use name of scene - that will be easier to manipulate order of scenes in build manager
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
