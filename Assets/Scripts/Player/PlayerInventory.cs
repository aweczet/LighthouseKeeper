using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Klasa obsługująca ekwipunek oraz jego pokazywanie pod TAB
///</summary>
public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public bool[] isFull;
    [HideInInspector] public GameObject[] slots;

    public GameObject[] items;
    [HideInInspector] public GameObject[] itemIcon;
    [HideInInspector] public string[] itemTag;

    [HideInInspector] public bool isActive = false;
    [HideInInspector] public int activeItemID = 0;
    [HideInInspector] public int lastAddedID = 0;

    private void Start()
    {
        isFull = new bool[items.Length];
        slots = new GameObject[items.Length];
        for (int i = 0; i < slots.Length; i++)
            slots[i] = GameObject.Find("UICanvas/Inventory/Inv" + (i + 1));
        itemIcon = new GameObject[items.Length];
        itemTag = new string[items.Length];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && !isEqEmpty())
        {
            if (isActive)
            {
                nextItem();
            }
            else
            {
                holdFirstItem();
            }
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            if (isActive)
            {
                dropItem();
            }
        }
    }

    private bool isEqEmpty()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i])
                return false;
        }

        return true;
    }

    public bool isEqFull()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            Debug.Log(isFull[i]);
            if (!isFull[i])
                return false;
        }

        return true;
    }

    private void dropItem()
    {
        isFull[activeItemID] = false;
        items[activeItemID].SetActive(false);
        Destroy(itemIcon[activeItemID]);
        Vector3 tempp = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 temp = new Vector3(tempp.x, tempp.y, tempp.z);
        temp += Camera.main.transform.forward;
        GameObject dropped = Instantiate(items[activeItemID], temp, new Quaternion(0, 110, 0, 1),
            GameObject.Find("Ground").transform);
        dropped.SetActive(true);
        dropped.GetComponent<ItemPickup>().nonQuestRelated = true;
        dropped.GetComponent<ItemPickup>().itemTag = itemTag[activeItemID];
        dropped.name = items[activeItemID].name;
        dropped.AddComponent<Rigidbody>();
        items[activeItemID] = null;
        itemTag[activeItemID] = "";
        isActive = false;
    }

    public void removeItemAfterQuest(int id){
        Debug.Log("removeitemafterquest "+id);
        isFull[id] = false;
        items[id].SetActive(false);
        Destroy(itemIcon[id]);
        items[id] = null;
        itemTag[id] = "";
        if(activeItemID == id)
            isActive = false;
    }

    private void nextItem()
    {
        for (int i = activeItemID + 1; i < isFull.Length; i++)
        {
            if (isFull[i])
            {
                items[activeItemID].SetActive(false);
                items[i].SetActive(true);
                activeItemID = i;
                return;
            }
        }

        items[activeItemID].SetActive(false);
        activeItemID = 0;
        isActive = false;
    }

    private void holdFirstItem()
    {
        activeItemID = 0;
        for (int i = activeItemID; i < isFull.Length; i++)
        {
            if (isFull[i])
            {
                items[i].SetActive(true);
                activeItemID = i;
                isActive = true;
                break;
            }
        }
    }
}