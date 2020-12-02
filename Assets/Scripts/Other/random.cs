using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa odpowiada za wylosowanie numeru w barometrze oraz ustawienie wskazówki
/// (chyba) -> w razie pytań tą klasę pisał Marko
/// </summary>

public class random : MonoBehaviour
{
    //public Text numerek;
    int losowa;
    public int zmienna=0;
    public Transform wskazowka;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Random.Range(1, 3));
        losowa = Random.Range(0, -180)+90;
        //numerek.text = " " + Random.Range(1, 3);
        //wskazowka.eulerAngles = new Vector3(0, 0, Random.Range(0, losowa) - losowa / 2);
        wskazowka.eulerAngles = new Vector3(0,-121, losowa);
        //Debug.Log(losowa);
        
    }
    //public random()
    //{
    //    this.zmienna = zmienna;
    //}
    public void liczby()
    {
        
        if (losowa <= 90 && losowa >= 55)
        {
            zmienna = 1;
            Debug.Log(zmienna);
        }
        else if (losowa <= 55 && losowa >= 0)
        {
            zmienna = 2;
            Debug.Log(zmienna);
        }
        else if (losowa <= 0 && losowa >= -55)
        {
            zmienna = 3;
            Debug.Log(zmienna);
        }
        else
        {
            zmienna = 4;
            Debug.Log(zmienna);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
