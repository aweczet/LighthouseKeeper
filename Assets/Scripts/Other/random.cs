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
    public int losowa=0;
    public int zmienna=0;
    public Transform wskazowka;
    int tymczasowa;
    // Start is called before the first frame update
    void Awake()
    {
        losowa = Random.Range(0, -180) + 90;
        Debug.Log("Losowa: " + losowa);
    
        wskazowka.eulerAngles = new Vector3(0, -121, losowa);
        liczby();
    }
 
    //public random()
    //{
    //    this.zmienna = zmienna;
    //}
    public void liczby()
    {
        //losowa = Random.Range(0, -180) + 90;
        Debug.Log("Losowa w funkcji:" + losowa);
       
        if (losowa <= 90 && losowa >= 55)
        {
            zmienna = 1;
            Debug.Log("Pierwsza zmienna" +zmienna);
        }
        else if (losowa <= 55 && losowa >= 0)
        {
            zmienna = 2;
            Debug.Log("Druga zmienna" + zmienna);
        }
        else if (losowa <= 0 && losowa >= -55)
        {
            zmienna = 3;
            Debug.Log("Trzecia zmienna" + zmienna);
        }
        else
        {
            zmienna = 4;
            Debug.Log("Czwarta zmienna" + zmienna);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
