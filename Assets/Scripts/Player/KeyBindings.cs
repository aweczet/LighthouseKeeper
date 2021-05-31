using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Klasa posiadająca bindy klawiszy
///</summary>

public class KeyBindings : MonoBehaviour
{
    [HideInInspector] private PlayerInventory inv;
    [HideInInspector] private GameObject Helpbox;
    [HideInInspector] private Camera camera;
    [HideInInspector] private GameObject hud;

    void Start(){
        inv = gameObject.GetComponent<PlayerInventory>();
        Helpbox = GameObject.FindGameObjectWithTag("Helpbox");
        Helpbox.SetActive(false);
        camera = Camera.main;
        hud = GameObject.Find("UICanvas");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) && !inv.isEqEmpty())
        {
            if(inv.isActive && inv.activeItemID == 0)
            {
                inv.stopHolding();
            }
            else
            {
                inv.holdXItem(0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) && !inv.isEqEmpty())
        {
            if(inv.isActive && inv.activeItemID == 1)
            {
                inv.stopHolding();
            }
            else
            {
                inv.holdXItem(1);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) && !inv.isEqEmpty())
        {
            if(inv.isActive && inv.activeItemID == 2)
            {
                inv.stopHolding();
            }
            else
            {
                inv.holdXItem(2);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4) && !inv.isEqEmpty())
        {
            if(inv.isActive && inv.activeItemID == 3)
            {
                inv.stopHolding();
            }
            else
            {
                inv.holdXItem(3);
            }
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            if (inv.isActive)
            {
                inv.dropItem();
            }
        }

        if(Input.GetKeyUp(KeyCode.J))
        {
            StartCoroutine(Blackout.blackout());
        }

        if(Input.GetKeyUp(KeyCode.F1))
        {
            if(Helpbox.activeSelf)
            {
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                camera.GetComponent<MouseLook>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<MouseLook>().enabled = false;
            }

            Helpbox.SetActive(!Helpbox.activeSelf);
        }
        else if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(Helpbox.activeSelf)
            {
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                camera.GetComponent<MouseLook>().enabled = true;
                Helpbox.SetActive(false);
            }
        }

        if(Input.GetKeyUp(KeyCode.H)){
            hud.SetActive(!hud.activeSelf);
        }
    }
}
