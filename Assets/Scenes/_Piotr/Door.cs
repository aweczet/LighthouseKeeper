using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    bool enter = false;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpen", false);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    enter = true;    
    //    //OpenDoor();
             
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    enter = false;
    //    CloseDoor();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && enter)
    //    {
    //        OpenDoor();

    //    }
    //}
}
