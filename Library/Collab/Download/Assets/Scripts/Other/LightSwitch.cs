using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightSwitch : MonoBehaviour
{

    //public bool onSwitch;
   // public bool lightStatus;
    public GameObject theLight;

    public void toggleLight()
    {
        if (theLight.active == true)
            theLight.SetActive(false);
        else
            theLight.SetActive(true);
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    onSwitch = true;
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    onSwitch = false;
    //}

    //void Update()
    //{
    //    if (theLight.active == true)
    //    {
    //        lightStatus = true;
    //    }
    //    else
    //    {
    //        lightStatus = false;
    //    }

    //    if (onSwitch)
    //    {
    //        if (lightStatus)
    //        {
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                theLight.SetActive(false);
    //            }
    //        }
    //        else
    //        {
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                theLight.SetActive(true);
    //            }
    //        }
    //    }
    //}

    //void OnGUI()
    //{
    //    if (onSwitch)
    //    {
    //        if (lightStatus)
    //        {
    //            GUI.Box(new Rect(0, 0, 200, 20), "Press E to close the light");

    //        }
    //        else
    //        {
    //            GUI.Box(new Rect(0, 0, 200, 20), "Press E to open the light");
    //        }
    //    }
    //}
}
