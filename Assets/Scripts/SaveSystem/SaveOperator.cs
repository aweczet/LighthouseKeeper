using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOperator : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    
    public void DeleteSave()
    {
        SaveSystem.DeleteData();
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