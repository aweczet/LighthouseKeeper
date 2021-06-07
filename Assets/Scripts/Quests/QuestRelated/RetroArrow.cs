using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroArrow : MonoBehaviour
{
    private Player player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update(){
        if(player.isRetrospection && player.activeQuestID == player.quests.Length - 1){
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
