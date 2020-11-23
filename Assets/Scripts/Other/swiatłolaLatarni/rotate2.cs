using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotate2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float sec = 8f;
    void Start()
    {
        if (gameObject.active)
            StartCoroutine(LateCall());
    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
       
        SceneManager.LoadScene("retrospekcja");
    }

    void Update()
    {
        transform.Rotate(new Vector3(40f, 0, 0)*Time.deltaTime); //applying rotation.
    }
}
