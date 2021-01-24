using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour
{
    public Image fuel;
    // Start is called before the first frame update
    void Start()
    {
        fuel.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel.fillAmount > 0.0f)
        {
            fuel.fillAmount -= .1f * Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            fuel.fillAmount += .3f;
        }
    }
}
