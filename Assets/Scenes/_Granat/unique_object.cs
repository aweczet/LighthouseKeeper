using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unique_object : MonoBehaviour
{
    public GameObject uniquepickup1;
    public GameObject uniquepickup2;
    public GameObject uniquepickup3;
    public GameObject uniqueobject1;
    public GameObject uniqueobject2;
    public GameObject uniqueobject3;

    void Start()
    {
        if (uniqueobject1 != null)
            uniqueobject1.SetActive(Player.unique_collected_1);
        if (uniqueobject2 != null)
            uniqueobject2.SetActive(Player.unique_collected_2);
        if (uniqueobject3 != null)
            uniqueobject3.SetActive(Player.unique_collected_3);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 7) && Input.GetMouseButtonUp(0))
        {
            var selection = hit.transform;
            if (selection.gameObject == uniquepickup1)
            {
                Player.unique_collected_1 = true;
                Destroy(uniquepickup1);
            }
            if (selection.gameObject == uniquepickup2)
            {
                Player.unique_collected_2 = true;
                Destroy(uniquepickup2);
            }
            if (selection.gameObject == uniquepickup3)
            {
                Player.unique_collected_3 = true;
                Destroy(uniquepickup3);
            }
        }
        if (Player.unique_collected_1 == true && uniqueobject1 != null)
        {
            uniqueobject1.SetActive(true);
        }
        if (Player.unique_collected_2 == true && uniqueobject2 != null)
        {
            uniqueobject2.SetActive(true);
        }
        if (Player.unique_collected_3 == true && uniqueobject3 != null)
        {
            uniqueobject3.SetActive(true);
        }
    }
}
