using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za zmianę koloru flagi. Wyjaśnia się sama w sobie
/// </summary>
public class ColorChange
{
    public Material material;
    private readonly Color[] _colors = {Color.green, Color.blue, Color.yellow, Color.red};

    public ColorChange(GameObject flag, int colorID)
    {
        material = flag.GetComponent<Renderer>().material;
        material.color = _colors[colorID];
    }

    // private GameObject flag;
    // private Material material;
    // //private random barometr;
    //
    // 
    // private int it = 0;
    //
    //
    // public ColorChange(GameObject flag, int it)
    // {
    //     this.flag = flag;
    //     this.it = it;
    //     material = 
    //     ChangeColor();
    //     
    // }
    // public void ChangeColor(int it)
    // {
    //     this.it = it;
    //     ChangeColor();
    // }
    // public void ChangeColor()
    // {
    //     it = it > colors.Length - 1 ? it % colors.Length : it;
    //     material.color = colors[it];
    // }
}