using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

///<summary>
///Klasa odpowiadająca za dialog w retrospekcji
///</summary>

public class RetrospectionTalk : MonoBehaviour
{

    public GameObject player;
    public string[] dialogi;
    private PlayerInventory inventory;
    public GameObject key;

    private void Start() {
        inventory = player.GetComponent<PlayerInventory>();
    }
    public void onMouseDown(){
        StartCoroutine(talk());
    }

    IEnumerator talk(){
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        MouseLook mouselook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();
        movement.enabled = false;
        mouselook.enabled = false;
        GameObject textbox = player.GetComponent<Player>().monologbox;
        TextMeshProUGUI text = textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textbox.SetActive(true);
        foreach(string dialog in dialogi){
            text.SetText(dialog);
            yield return new WaitForSeconds(0.3f);
            yield return StartCoroutine(WaitForClick());
            
        }
        textbox.SetActive(false);
        text.SetText("");
        movement.enabled = true;
        mouselook.enabled = true;

        for (int i = 0; i < inventory.slots.Length; i++) {
            if(inventory.isFull[i] == false) {
                inventory.isFull[i] = true;
                GameObject uiitem = Instantiate(key, inventory.slots[i].transform, false);
                uiitem.SetActive(true);
                inventory.items[i] = GameObject.Find("First Person Player/HeldItem/key");
                inventory.itemTag[i] = "key";
                break;
            }
        }
    }

    IEnumerator WaitForClick(){
        while(true){
            if(Input.GetMouseButtonDown(0)){
                yield break;
            }
            yield return null;
        }
    }

}
