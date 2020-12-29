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
    int nextScene;
    void Start()
    {
        if (gameObject.active)
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            StartCoroutine(LateCall());
        }
    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(nextScene);
    }

    void Update()
    {
        transform.Rotate(new Vector3(40f, 0, 0)*Time.deltaTime); //applying rotation.
    }
}
