using System;
using UnityEngine;

public class SaveOperator : MonoBehaviour
{
    private GameObject _canvasPanel;
    private bool _visible;
    private Transform _player;
    private MouseLook _mouseLook;
    private void Start()
    {
        _canvasPanel = GameObject.Find("Canvas/testUIPanel");
        _player = GameObject.FindWithTag("Player").transform;
        _mouseLook = _player.GetChild(1).GetComponent<MouseLook>();
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

    public void SavePlayer()
    {
        Debug.Log("Save player pos:\t" + _player.position);
        SaveSystemTest.SavePlayer(_player);
    }

    public void LoadPlayer()
    {
        _player.GetComponent<PlayerMovement>().gameObject.SetActive(false);
        PlayerDataTest data = SaveSystemTest.LoadPlayer();
        _player.position = data.LoadPosition(data.playerPosition);
        Debug.Log("Load player pos:\t" + _player.position);
        _player.GetComponent<PlayerMovement>().gameObject.SetActive(true);
    }
}
