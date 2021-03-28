using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAngle : MonoBehaviour
{
    public int speed;
    public 
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
