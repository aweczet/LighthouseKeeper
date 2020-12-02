﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa odpowiada za licznik FPS w prawym górnym rogu
/// </summary>

public class FPSCounter : MonoBehaviour
{
    public Text displayText;
    public float refreshRate = 1f;

    private float timer;

    public void Update()
    {
        if(Time.unscaledTime > timer)
        {
            float fps = (int)(1f / Time.unscaledDeltaTime);
            displayText.text = "FPS: " + fps;
            timer = Time.unscaledTime + refreshRate;
        }

    }
}