using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotate2 : MonoBehaviour
{
    public Player player;
    public float sec = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // Dodaje scene następną (dzień 4/retrospekcja) do Stosu (dlatego +1)
        player.addSceneToStack(SceneManager.GetActiveScene().buildIndex +1);
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
        
        // nie działa
        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Menu
        // }
    }
}
