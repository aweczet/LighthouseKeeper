using System;
using UnityEngine;

public class SaveOperator : MonoBehaviour
{
    private GameObject _canvasPanel;
    private bool _visible;
    private Transform _player;
    private MouseLook _mouseLook;
    private FuelTank _fueltank;

    private void Start()
    {
        _canvasPanel = GameObject.Find("Canvas/testUIPanel");
        _player = GameObject.FindWithTag("Player").transform;
        _mouseLook = _player.GetChild(1).GetComponent<MouseLook>();
        _fueltank = GameObject.Find("fueltank").transform.GetComponent<FuelTank>();
        ToggleUI(_visible);
        Debug.Log("start:\t" + _fueltank);
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
        Debug.Log("save:\t" + _fueltank);
        SaveSystemTest.SavePlayer(_player);
        SaveSystemTest.SaveFuelTank(_fueltank);
    }

    public void LoadPlayer()
    {
        _player.GetComponent<PlayerMovement>().gameObject.SetActive(false);
        PlayerDataTest data = SaveSystemTest.LoadPlayer();
        _player.position = data.LoadPosition(data.playerPosition);
        _player.GetComponent<PlayerMovement>().gameObject.SetActive(true);

        Debug.Log("load:\t" + _fueltank);
        FuelData fuelData = SaveSystemTest.LoadFuelTank();
        Debug.Log("load2:\t" + _fueltank.fuelAmount);
        Debug.Log("load3:\t" + fuelData);
        _fueltank.fuelAmount = fuelData.fuelAmount;
    }
}