using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private Lightingpreset preset;

    [SerializeField, Range(0, 24)] private float timeOfDay;
    private float timeSpeed = .5f;

    private float maxTime = 6f;
    private float timeInterval;

    private Player player;
    private int numberOfCurrentQuests;
    private bool lastQuest = false;     

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        numberOfCurrentQuests = player.numberOfActiveQuests + 1;
        timeInterval = (12f / numberOfCurrentQuests);
        maxTime += timeInterval;
    }

    private void Update()
    {
        lastQuest = player.numberOfActiveQuests == numberOfCurrentQuests;
        if (lastQuest)
            numberOfCurrentQuests++;

        if (player.numberOfActiveQuests + 1 < numberOfCurrentQuests)
        {
            maxTime = maxTime + timeInterval >= 24f ? 23.9f : maxTime + timeInterval;
            numberOfCurrentQuests = player.numberOfActiveQuests + 1;
        }

        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            if(timeOfDay < maxTime )
            {
                timeOfDay += Time.deltaTime / timeSpeed;
                timeOfDay %= 24;

                if ((timeOfDay / 24f) == .04)
                    Debug.Log("1 am");
                UpdateLighting(timeOfDay / 24f);
            }
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }
    

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);
        RenderSettings.skybox.SetColor("_Tint", preset.SkyboxColor.Evaluate(timePercent));

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);

            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }
}