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
    private Player _player;
    public float sec = 5f;
    int nextScene;
    int lighter_used;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // Dodaje scene następną (dzień 2) do Stosu (dlatego +1)
        //player.addSceneToStack(SceneManager.GetActiveScene().buildIndex +1);
        if (gameObject.active)
        {
            SaveSystem.SaveGame(_player);
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

        // nie działa
        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Menu
        // }
    }
}
