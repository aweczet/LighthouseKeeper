using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Klasa obsługująca ekwipunek oraz jego pokazywanie pod TAB
///</summary>
public class PlayerInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject[] items;
    public GameObject[] itemIcon;
    public string[] itemTag;
    public GameObject info;

    public bool isActive = false;
    public int activeItemID = 0;


    /*private void Update() {
        if (Input.GetKey(KeyCode.Tab))
            info.SetActive(true);
        else
            info.SetActive(false);
    }*/

    private void Update(){
        if(Input.GetKeyUp(KeyCode.Tab) && !isEqEmpty()){
            if(isActive){
                for(int i = activeItemID+1; i < isFull.Length; i++){
                    if(isFull[i]){
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
            else{
                activeItemID = 0;
                for(int i = activeItemID; i < isFull.Length; i++){
                    if(isFull[i]){
                        items[i].SetActive(true);
                        activeItemID = i;
                        isActive = true;
                        break;
                    }
                }
            }
            
        }

        if(Input.GetKeyUp(KeyCode.G)){
            if(isActive){
                isFull[activeItemID] = false;
                itemTag[activeItemID] = "";
                items[activeItemID].SetActive(false);
                Destroy(itemIcon[activeItemID]);
                Vector3 tempp = GameObject.FindGameObjectWithTag("Player").transform.position;
                Vector3 temp = new Vector3(tempp.x, tempp.y, tempp.z);
                temp += Camera.main.transform.forward;
                Debug.Log(temp.y);
                Instantiate(items[activeItemID], temp, new Quaternion(0, 110, 0, 1), GameObject.Find("Ground").transform).SetActive(true);
                items[activeItemID] = null;
                isActive = false;
            }
        }
    }

    private bool isEqEmpty(){
        for(int i = 0; i < isFull.Length; i++){
            if(isFull[i])
                return false;
        }
        Debug.Log(true);
        return true;
    }

    private void dropItem(){

    }
}
