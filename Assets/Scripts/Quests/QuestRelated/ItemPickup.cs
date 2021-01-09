using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///Klasa dodająca ikonkę podniesionego przedmiotu do ekwipunku
///</summary>
public class ItemPickup : MonoBehaviour
{
    private PlayerInventory inventory;
    public GameObject itemButton;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    private void OnDestroy() {
        for (int i = 0; i < inventory.slots.Length; i++) {
            if(inventory.isFull[i] == false) {
                inventory.isFull[i] = true;
                GameObject uiitem = Instantiate(itemButton, inventory.slots[i].transform, false);
                uiitem.SetActive(true);
                inventory.items[i] = GameObject.Find("First Person Player/HeldItem/"+gameObject.name);
                break;
            }
        }
    }

}
