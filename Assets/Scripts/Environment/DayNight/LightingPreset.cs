using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Lighting preset", menuName = "Scriptables/Lighting preset", order = 1)]
public class Lightingpreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
    public Gradient SkyboxColor;

}