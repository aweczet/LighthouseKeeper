using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Klasa dodająca ikonkę podniesionego przedmiotu do ekwipunku
///</summary>
public class ItemPickup : MonoBehaviour
{
    [HideInInspector] public PlayerInventory inventory;
    public GameObject itemButton;
    public string itemTag;
    public bool nonQuestRelated = false;
    public bool foodWithBook = false;
    private GameObject arrow;
    
    public void Start()
    {
        arrow = GameObject.Find("Environment/QuestRelated/Locations/czytanie");
        if(arrow)
            arrow.SetActive(false);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        //DontDestroyOnLoad(itemButton);
    }

    public void pickUpItem()
    {   
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                inventory.itemIcon[i] = Instantiate(itemButton, inventory.slots[i].transform, false);
                inventory.itemIcon[i].SetActive(true);
                if(foodWithBook){
                    inventory.items[i] = GameObject.Find("First Person Player/HeldItem/book1");
                    Debug.Log(arrow.activeSelf);
                    arrow.SetActive(true);
                }
                else
                    inventory.items[i] = GameObject.Find("First Person Player/HeldItem/" + gameObject.name);
                inventory.itemTag[i] = itemTag;
                inventory.lastAddedID = i;
                return;
            }
        }
    }

    public void pickupFoodWithBook(){
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                inventory.itemIcon[i] = Instantiate(itemButton, inventory.slots[i].transform, false);
                inventory.itemIcon[i].SetActive(true);
                inventory.items[i] = GameObject.Find("First Person Player/HeldItem/book1");
                inventory.itemTag[i] = itemTag;
                inventory.lastAddedID = i;
            
                return;
            }
        }
    }
    
}