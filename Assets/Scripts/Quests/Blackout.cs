using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa zawieracjąca funkcję do ściemniania ekranu w finalnej scenie
/// </summary>
public class Blackout
{
    static public void blackout()
    {
        Animator anim = GameObject.Find("UICanvas/Blackout").GetComponent<Animator>();
        anim.enabled = true;
        //anim.SetBool("startBlackout",true);
    }
}