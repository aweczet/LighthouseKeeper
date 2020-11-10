using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private ISelectionResponse _selectionResponse;

    private Transform _selection;
    public PickUp pickUp = new PickUp();
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
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    void Update()
    {
        if (_selection != null)
        {
            //
            _selectionResponse.OnDeselect(_selection);
        }


        #region MyRegion
        // Creating a Ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Selection Determination
        _selection = null;
        if (Physics.Raycast(ray, out var hit, 7))
        {
            

            var selection = hit.transform;
            
            if (selection.CompareTag(selectableTag))
            {
                PickUp.OpenMessagePanel("");
                _selection = selection;

                // Only to test
                if (Input.GetMouseButtonUp(0))
                {
                    _selection.transform.localScale = new Vector3(_selection.transform.localScale.x * -1,
                        _selection.transform.localScale.y,
                        _selection.transform.localScale.z * -1);

                    Debug.Log(_selection.name);
                    
                    xDDD = (int)Time.deltaTime;
                    if (xDDD % 2 == 0)
                        FindObjectOfType<AudioManager>().Play("switch_on");

                    else
                        FindObjectOfType<AudioManager>().Play("switch_off");
                }
            }
        } 
        #endregion

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
