using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za przełączenie światła ?
/// w razie pytań tą klasę pisał Marko
/// </summary>


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
