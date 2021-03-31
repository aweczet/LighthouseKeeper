using UnityEngine;

/// <summary>
/// Preset, który służy do zmian kolorów oświetlenia
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "Lighting preset", menuName = "Scriptables/Lighting preset", order = 1)]
public class Lightingpreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
    public Gradient skyboxColor;
}