using UnityEngine;

/// <summary>
/// Preset, który służy do zmian kolorów oświetlenia
/// </summary>
[System.Serializable]
[CreateAssetMenu(fileName = "LightingPreset", menuName = "Scriptables/LightingPreset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
    public Gradient skyboxColor;
}