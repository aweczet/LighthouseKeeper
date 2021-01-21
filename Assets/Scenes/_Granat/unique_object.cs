using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unique_object : MonoBehaviour
{
    public GameObject uniquepickup;
    public GameObject uniqueobject;
    private Player player;

    void Start()
    {
        uniqueobject.SetActive(Player.collected_1);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 7) && Input.GetMouseButtonDown(0) && uniquepickup.name == "Unique1")
        {
            Player.collected_1 = true;
            Destroy(uniquepickup);
        }
        if (Player.collected_1 == true && uniqueobject != null)
        {
            uniqueobject.SetActive(true);
        }
    }
}
