using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_scene : MonoBehaviour
{
    int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.active)
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
