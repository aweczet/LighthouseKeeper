using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int min;
    public int max;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    private void Update()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }
}