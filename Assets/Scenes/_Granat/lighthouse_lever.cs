using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighthouse_lever : MonoBehaviour
{
    public GameObject lampshade;
    public GameObject lever;
    private bool lever_turned_on = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lever_turned_on == false)
            {
                lever_turned_on = true;
                lever.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                lampshade.transform.Translate(0.0f, 3.0f, 0.0f);
            }
            else
            {
                lever_turned_on = false;
                lever.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                lampshade.transform.Translate(0.0f, -3.0f, 0.0f);
            }
        }
    }

}
