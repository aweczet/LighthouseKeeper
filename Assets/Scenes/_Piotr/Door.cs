using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animator;
    
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

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
    }


    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
