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
            uniqueobject1.SetActive(Player.UniqueCollected1);
        if (uniqueobject2 != null)
            uniqueobject2.SetActive(Player.UniqueCollected2);
        if (uniqueobject3 != null)
            uniqueobject3.SetActive(Player.UniqueCollected3);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 7) && Input.GetMouseButtonUp(0))
        {
            var selection = hit.transform;
            if (selection.gameObject == uniquepickup1)
            {
                Player.UniqueCollected1 = true;
                Destroy(uniquepickup1);
            }
            if (selection.gameObject == uniquepickup2)
            {
                Player.UniqueCollected2 = true;
                Destroy(uniquepickup2);
            }
            if (selection.gameObject == uniquepickup3)
            {
                Player.UniqueCollected3 = true;
                Destroy(uniquepickup3);
            }
        }
        if (Player.UniqueCollected1 == true && uniqueobject1 != null)
        {
            uniqueobject1.SetActive(true);
        }
        if (Player.UniqueCollected2 == true && uniqueobject2 != null)
        {
            uniqueobject2.SetActive(true);
        }
        if (Player.UniqueCollected3 == true && uniqueobject3 != null)
        {
            uniqueobject3.SetActive(true);
        }
    }
}
