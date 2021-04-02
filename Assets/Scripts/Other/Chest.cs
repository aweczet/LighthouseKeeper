using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    
    private GameObject player;
    private Camera camera;

    private bool isOpened = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
    }

    void Update(){
        if(isOpened && Input.GetKeyDown(KeyCode.Escape)){
            isOpened = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            camera.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnMouseUp(){
        if(gameObject.GetComponent<Outline>().OutlineWidth > 0){
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            isOpened = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
