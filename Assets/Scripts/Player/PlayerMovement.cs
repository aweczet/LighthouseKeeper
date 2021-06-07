using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za poruszanie się gracza
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistande = .4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

   

    // Update is called once per frame
    void Update()
    {
        // Sprawdzenie czy gracz jest na ziemi
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistande, groundMask);

        // Upewnienie się, że gracz będzie na ziemi jeżeli nie skacze
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        

        controller.Move(move * speed * Time.deltaTime);


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
       
    }
}
