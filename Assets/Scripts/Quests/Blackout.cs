using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa zawieracjąca funkcję do ściemniania ekranu w finalnej scenie
/// </summary>
public class Blackout
{
    static public IEnumerator blackout()
    {
        Animator anim = GameObject.Find("UICanvas/Blackout").GetComponent<Animator>();
        Animator cred = GameObject.Find("UICanvas/Credits").GetComponent<Animator>();
        anim.enabled = true;
        yield return new WaitForSeconds(5);
        Debug.Log("end wait");
        cred.enabled = true;
        yield return new WaitForSeconds(18);
        Debug.Log("end wait");
        cred.enabled = false;
        //anim.SetBool("startBlackout",true);
    }
}