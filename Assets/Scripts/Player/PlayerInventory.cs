using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Klasa obsługująca ekwipunek oraz jego pokazywanie pod TAB
///</summary>
public class PlayerInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject info;

    private void Update() {
        if (Input.GetKey(KeyCode.Tab))
            info.SetActive(true);
        else
            info.SetActive(false);
    }
}
