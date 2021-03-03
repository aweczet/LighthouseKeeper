using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa odpowiada za licznik FPS w prawym górnym rogu
/// </summary>

public class FPSCounter : MonoBehaviour
{
    public Text displayText;
    public float refreshRate = 1f;

    private float _timer;

    private void Start()
    {
        DisplayFPS();
    }

    private void Update()
    {
        if(Time.unscaledTime > _timer)
        {
            DisplayFPS();
        }
    }

    private void DisplayFPS()
    {
        float fps = (int)(1f / Time.unscaledDeltaTime);
        displayText.text = "FPS: " + fps;
        _timer = Time.unscaledTime + refreshRate;
    }
}