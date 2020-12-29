using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///Klasa dodająca ikonkę książki do ekwipunku
///</summary>
public class BookPickup : MonoBehaviour
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
                GameObject uibook = Instantiate(itemButton, inventory.slots[i].transform, false);
                uibook.SetActive(true);
                break;
            }
        }
    }

}
