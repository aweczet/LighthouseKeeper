using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za sterowanie myszą
/// </summary>
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    private float _maxMouseSensitivity = 150;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody.Rotate(Vector3.up * 90);
        LockMouse();
    }

    public void LockMouse(bool mode = false)
    {
        if (!mode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseSensitivity = _maxMouseSensitivity;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            mouseSensitivity = 0;
        }

        Cursor.visible = mode;
    }

    // Update is called once per frame
    // Generalnie obraca kamerę biorąc pod uwagę nasz kursor myszy
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        // Zabezpieczenie przed spojrzeniem za bardzo w górę lub w dół
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}