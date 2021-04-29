using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiadająca za przełączanie scen w MainMenu
/// </summary>


public class MainMenu : MonoBehaviour
{
    private Player _player;
    public GameObject CanvasMainMenu, CanvasSettingsMenu;
    
    private void Start() {
        SetUpCursor();
        _player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
        CanvasSettingsMenu.gameObject.SetActive(false);
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
        CanvasMainMenu.gameObject.SetActive(false);
        CanvasSettingsMenu.gameObject.SetActive(true);
    }

    public void GoToMainMenu() {
        CanvasSettingsMenu.gameObject.SetActive(false);
        CanvasMainMenu.gameObject.SetActive(true);
    }
   
    public void QuitGame() {
        Application.Quit();
    }
}
