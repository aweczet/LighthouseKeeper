using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiada za ??? Po nazwie domyślam się, że obrót latarni?
/// Są 3 takie same klasy rotate, rotate1, rotate2
/// w razie pytań tą klasę pisał Marko
/// </summary>

public class rotate : MonoBehaviour
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
       
        SceneManager.LoadScene("Drugi dzień");
    }

    void Update()
    {
        transform.Rotate(new Vector3(40f, 0, 0)*Time.deltaTime); //applying rotation.
    }
}
