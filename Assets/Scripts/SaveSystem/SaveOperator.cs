using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOperator : MonoBehaviour
{
    private Player _player;
    private bool _cursor;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    
    public void DeleteSave()
    {
        SaveSystem.DeleteData();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ToggleCursor();
        }
    }

    private void ToggleCursor()
    {
        if (_cursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        _cursor = !_cursor;
    }

    public void ContinueGame()
    {
        Debug.LogWarning("Continue");
        LighthouseData data = SaveSystem.LoadGame();
        if (data == null) return;
        SceneManager.LoadScene(data.sceneId);
    }

    public void NewGame()
    {
        Debug.LogWarning("NewGame");
        DeleteSave();
        // First ever scene (prologue) id
        SceneManager.LoadScene(1);
    }
}