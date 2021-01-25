using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class lightOff : MonoBehaviour
{
    public GameObject light;
    private Light lightSource;
    int nextScene;

    private void Start()
    {
        lightSource = light.GetComponent<Light>();
    }

    void Update()
    {
        if (lightSource.intensity <= 0)
        {
            light.SetActive(false);
        }
        
        if (gameObject.active && Input.GetKeyDown(KeyCode.K))
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
    }
}
