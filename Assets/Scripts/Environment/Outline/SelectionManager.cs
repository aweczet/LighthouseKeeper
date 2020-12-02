using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa pozwalająca na wykrycie obiektu na który najeżdżamy myszą oraz wyświetlenie outline'u
/// </summary>

public class SelectionManager : MonoBehaviour
{
    // Ustalenie tagu po jakim będziemy decydować czy obiekt jest możliwy do zaznaczenia
    [SerializeField] private string selectableTag = "Selectable";

    private ISelectionResponse _selectionResponse;
    private Transform _selection;

    private Player player;
    
    // Zmienna do usunięcia!
    private int xDDD;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    void Update()
    {
        if (_selection != null)
        {
            _selectionResponse.OnDeselect(_selection);
        }

        // Wysyłanie promień idący od kamery w kierunku w który patrzy kamera (u nas gracz)
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        _selection = null;
        // Sprawdzenie czy cokolwiek w odległości 7 jednostek jest przebite przez promień
        if (Physics.Raycast(ray, out var hit, 7))
        {
            // Zaznaczenie przebity obiekt jako selection
            var selection = hit.transform;
            
            // Sprawdza czy zaznaczenie ma tag "Selectable"
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;

                // Sprawdza czy został naciśnięty lewy przycisk myszy
                if (Input.GetMouseButtonUp(0))
                {
                    // Wywołuje metodę w skrypcie gracza (Player.cs)
                    player.PressedOnSelectable(_selection.gameObject);


                    // TESTOWE ODTWARZANIE DŹWIĘKU PO KLIKNIĘCIU NA ZAZNACZONY OBIEKT
                    // DO ZMIANY!!!!
                    xDDD = (int)Time.deltaTime;
                    if (xDDD % 2 == 0)
                        FindObjectOfType<AudioManager>().Play("switch_on");

                    else
                        FindObjectOfType<AudioManager>().Play("switch_off");
                }
            }
        } 

        if(_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }
    }
}
