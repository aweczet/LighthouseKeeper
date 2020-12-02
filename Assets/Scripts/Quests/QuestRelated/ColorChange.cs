using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za zmianę koloru flagi. Wyjaśnia się sama w sobie
/// </summary>

public class ColorChange
{
    private GameObject flag;
    private Material material;
    //private random barometr;
    
    private Color[] colors = { Color.green, Color.blue, Color.yellow, Color.red};
    private int it = 0;


    public ColorChange(GameObject flag, int it)
    {
        this.flag = flag;
        this.it = it;
        material = this.flag.GetComponent<Renderer>().material;
        ChangeColor();
        
    }
    public void ChangeColor(int it)
    {
        this.it = it;
        ChangeColor();
    }
    public void ChangeColor()
    {
        it = it > colors.Length - 1 ? it % colors.Length : it;
        material.color = colors[it];
    }
}
