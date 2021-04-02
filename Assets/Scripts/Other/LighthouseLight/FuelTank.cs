using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour
{
    public Image fuel;

    // [HideInInspector] 
    public float fuelAmount; 
    
    // Start is called before the first frame update
    void Start()
    {
        fuelAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelAmount > 0.0f)
        {
            fuelAmount -= .1f * Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            fuelAmount += .3f;
        }

        fuel.fillAmount = fuelAmount;
    }
}
