using UnityEngine;

/// <summary>
/// Klasa odpowiadająca za "wyświetlenie" outline
/// </summary>

public class OutlineSelectionResonse : MonoBehaviour, ISelectionResponse
{
    // Po zaznaczeniu obiektu zostaje zmieniona szerokość outline'u na 10
    public void OnSelect(Transform selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null)
        {
            outline.OutlineWidth = 10;
        }
    }

    // Jeżeli już nie zaznaczamy obiektu to szerokość outline'u zostaje zmieniona na 0
    public void OnDeselect(Transform selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null)
            outline.OutlineWidth = 0; 
    }
}
