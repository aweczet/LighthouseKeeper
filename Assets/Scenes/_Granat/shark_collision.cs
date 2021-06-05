using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark_collision : MonoBehaviour
{
    private int _sharkHealth = 100;

    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("harpoon")) return;
        _sharkHealth -= 34;
        Debug.Log("hit detected " + _sharkHealth);
    }

    private void Update()
    {
        if (_sharkHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
