using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightSwitch
{
    public GameObject theLight;

    public LightSwitch(GameObject theLight)
    {
        this.theLight = theLight;
        toggleLight();
    }

    public void toggleLight()
    {
        if (theLight.activeInHierarchy)
            theLight.SetActive(false);
        else
            theLight.SetActive(true);
    }
}
