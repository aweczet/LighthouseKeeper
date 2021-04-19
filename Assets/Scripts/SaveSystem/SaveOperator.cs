using System;
using UnityEngine;

public class SaveOperator : MonoBehaviour
{
    private GameObject _canvasPanel;
    private bool _visible;
    private Transform _playerTransform;
    private Player _player;
    private MouseLook _mouseLook;
    private FuelTank _fueltank;

    private void Start()
    {
        _canvasPanel = GameObject.Find("testUIPanel");
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _player = _playerTransform.GetComponent<Player>();
        _mouseLook = _playerTransform.GetChild(1).GetComponent<MouseLook>();
        _fueltank = GameObject.Find("fueltank").transform.GetComponent<FuelTank>();
        
        ToggleUI(_visible);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _visible = !_visible;
            ToggleUI(_visible);
        }
    }

    private void ToggleUI(bool visible)
    {
        _canvasPanel.SetActive(visible);
        _mouseLook.LockMouse(visible);
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteData();
    }
    
    public void SaveGame()
    {
        SaveSystem.SaveGame(_player);
    }

    public void LoadGame()
    {
        // _playerTransform.GetComponent<PlayerMovement>().gameObject.SetActive(false);
        // LighthouseData data = SaveSystem.LoadGame();
        // _playerTransform.position = data.FloatsToVector3(data.playerPosition);
        // _player.numberOfActiveQuests = data.numberOfActiveQuests;
        // for (int i = 0; i < data.questsStatus.Length; i++)
        // {
        //     _player.quests[i].isActive = data.questsStatus[i];
        // }
        //
        // _player.StrikeAllInactiveQuests();
        // _playerTransform.GetComponent<PlayerMovement>().gameObject.SetActive(true);
    }
}