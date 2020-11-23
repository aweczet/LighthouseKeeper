using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private ISelectionResponse _selectionResponse;
    public Text koniec1;
    private Transform _selection;

    private Player player;

    //public PickUp pickUp = new PickUp();
    // To delete
    private int xDDD;


    //// Only to test this is here
    //public AudioSource[] sounds = new AudioSource[3];
    //private bool hasPlayed = false;
    //private bool isOn = false;

    //private void Start()
    //{
    //    // Only to test
    //    gameObject.AddComponent<AudioSource>();
    //}

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


        // Creating a Ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Selection Determination
        _selection = null;
        if (Physics.Raycast(ray, out var hit, 7))
        {
            var selection = hit.transform;
            
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;

                if (Input.GetMouseButtonUp(0))
                {
                    player.PressedOnSelectable(_selection.gameObject);


                    // To fix (move to diffrent class)
                   // koniec1.text = "________________";
                    

                    //Debug.Log(_selection.name);
                    
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
            //pickUp.CloseMessagePanel();
            _selectionResponse.OnSelect(_selection);
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if(_selection!= null)
        //    {
        //        pickUp.OpenMessagePanel("");
        //    }
        //}
        //private void OnTriggerExit(Collider other)
        //{
        //    if(_selection != null)
        //    {
        //        pickUp.CloseMessagePanel();
        //    }
        //}
    }
}
