using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monolog_animacja : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Awake()
    { 
        StartCoroutine(LateCall());
    }

    // Update is called once per frame
    public IEnumerator LateCall()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        yield return new WaitForSeconds(3);
        anim.SetBool("fade_out_monolog",true);
    }
}
