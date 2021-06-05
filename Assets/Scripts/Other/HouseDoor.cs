using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoor : MonoBehaviour
{
    [HideInInspector] private Animator anim;
    
    void Awake(){
        anim = gameObject.GetComponent<Animator>();
    }
    void OnMouseUp(){
        if(gameObject.GetComponent<Outline>().OutlineWidth > 0){
            if(anim.GetBool("isOpen")){
                anim.SetBool("isOpen", false);
            }
            else{
                anim.SetBool("isOpen", true);
            }
        }
    }
}
