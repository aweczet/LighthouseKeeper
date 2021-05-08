using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark_collision : MonoBehaviour
{
    public GameObject shark;
    private int sharkHealth = 100;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "harpoon")
        {
            sharkHealth = sharkHealth - 34;
            Debug.Log("hit detected " + sharkHealth);
        }
    }

    void FixedUpdate()
    {
        if (sharkHealth <= 0)
        {
            Destroy(shark);
        }
    }
}
