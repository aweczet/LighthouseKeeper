using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ItemUseOnObject : MonoBehaviour
{
    PlayerInventory playereq;
    public string requiredItemTag;
    public objectType action;

    private void Start() {
        playereq = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void OnMouseDown() {
        if(gameObject.GetComponent<Outline>().OutlineWidth > 0.0f){
            if(playereq.isActive && playereq.itemTag[playereq.activeItemID] == requiredItemTag){
                switch(action){
                    case objectType.door_animation:
                        gameObject.GetComponent<Animator>().enabled = true;
                        break;
                    case objectType.book_putaway:
                        playereq.isFull[playereq.activeItemID] = false;
                        playereq.items[playereq.activeItemID].SetActive(false);
                        playereq.items[playereq.activeItemID] = null;
                        playereq.itemTag[playereq.activeItemID] = "";
                        playereq.isActive = false;
                        break;
                    case objectType.flag_setup:
                        random barometr = GameObject.FindGameObjectWithTag("barometr").GetComponent<random>();

                        String holdFlagId = playereq.items[playereq.activeItemID].gameObject.name;
                        holdFlagId = holdFlagId.Substring(holdFlagId.Length - 1);

                        if (barometr.zmienna == Int32.Parse(holdFlagId))
                        {
                            GameObject mainflag = GameObject.Find("main_flag/Flag");
                            Debug.Log(mainflag);
                            ColorChange flagMat = new ColorChange(mainflag, Int32.Parse(holdFlagId) - 1);
                            
                            playereq.isFull[playereq.activeItemID] = false;
                            playereq.items[playereq.activeItemID].SetActive(false);
                            playereq.items[playereq.activeItemID] = null;
                            playereq.itemTag[playereq.activeItemID] = "";
                            playereq.isActive = false;
                        }

                        break;
                    default:
                        return;
                }
            }
        }
    }

}

public enum objectType{
    door_animation,
    book_putaway,
    flag_setup
}