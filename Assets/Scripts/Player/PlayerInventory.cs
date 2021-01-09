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
    public GameObject info;

    private bool isSthInHand = false;
    private int it = 0;

    /*private void Update() {
        if (Input.GetKey(KeyCode.Tab))
            info.SetActive(true);
        else
            info.SetActive(false);
    }*/

    private void Update(){
        if(Input.GetKeyUp(KeyCode.Tab) && !isEqEmpty()){
            if(isSthInHand){
                for(int i = it+1; i < isFull.Length; i++){
                    if(isFull[i]){
                        items[it].SetActive(false);
                        items[i].SetActive(true);
                        it = i;
                        return;
                    }
                }
                items[it].SetActive(false);
                it = 0;
                isSthInHand = false;
            }
            else{
                for(int i = it; i < isFull.Length; i++){
                    if(isFull[i]){
                        items[i].SetActive(true);
                        it = i;
                        isSthInHand = true;
                        break;
                    }
                }
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
}
