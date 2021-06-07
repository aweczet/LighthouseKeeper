using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<summary>
///Klasa posiadająca bindy klawiszy
///</summary>

public class KeyBindings : MonoBehaviour
{
    [HideInInspector] private PlayerInventory inv;
    [HideInInspector] private GameObject Helpbox;
    [HideInInspector] private Camera camera;
    [HideInInspector] private GameObject hud;
    [HideInInspector] private GameObject doors;
    [HideInInspector] private TextMeshProUGUI text;
    public GameObject textbg;
    public GameObject ship;
    public GameObject openBook;
    public Animation dOpen;
    public Animation dClose;
    [HideInInspector] private bool doorsOpened = false;

    void Start(){
        inv = gameObject.GetComponent<PlayerInventory>();
        Helpbox = GameObject.FindGameObjectWithTag("Helpbox");
        Helpbox.SetActive(false);
        camera = Camera.main;
        hud = GameObject.Find("UICanvas");
        if(textbg)
            text = textbg.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        doors = GameObject.Find("Environment/Buildings/lighthouse_house/House.002");
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
            if(Helpbox && Helpbox.activeSelf)
            {
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                camera.GetComponent<MouseLook>().enabled = true;
                Helpbox.SetActive(false);
            }
        }

        if(Input.GetKeyUp(KeyCode.H)){
            GameObject.Find("UICanvas/Inventory").SetActive(false);
            GameObject.Find("UICanvas/QuestPanel").SetActive(false);
            GameObject.Find("UICanvas/Text").SetActive(false);
        }

        if(Input.GetKeyUp(KeyCode.M)){
            StartCoroutine(this.hoursPass());
        }

        if(Input.GetKeyUp(KeyCode.N)){
            openBook.SetActive(!openBook.activeSelf);
        }



    }

    private IEnumerator hoursPass(){
        Debug.Log("hoursPass");
        Animator anim = GameObject.Find("UICanvas/Blackout").GetComponent<Animator>();
        anim.enabled = true;
        yield return new WaitForSeconds(3);
        text.SetText("6 godzin później...");
        textbg.SetActive(true);
        yield return new WaitForSeconds(5);
        textbg.SetActive(false);
        yield return new WaitForSeconds(2);
        anim.enabled = false;
        ship.SetActive(true);
    }
}