using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiadająca za przełączanie scen w MainMenu
/// </summary>


public class MainMenu : MonoBehaviour
{
    private Player _player;
    public GameObject CanvasMainMenu, CanvasSettingsMenu;
    private LightingManager _lightingManager;

    private void Start() {
        SetUpCursor();
        _player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
        CanvasSettingsMenu.gameObject.SetActive(false);
        _lightingManager = FindObjectOfType<LightingManager>();
    }

    private void SetUpCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
