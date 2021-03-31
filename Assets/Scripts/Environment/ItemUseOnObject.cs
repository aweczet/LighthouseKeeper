using UnityEngine;

public class ItemUseOnObject : MonoBehaviour
{
    public string requiredItemTag;
    public ObjectType action;

    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    private void OnMouseDown()
    {
        if (!(gameObject.GetComponent<Outline>().OutlineWidth > 0.0f))
            return;
        if (!_playerInventory.isActive || _playerInventory.itemTag[_playerInventory.activeItemID] != requiredItemTag)
            return;
        switch (action)
        {
            case ObjectType.DoorAnimation:
                gameObject.GetComponent<Animator>().enabled = true;
                break;

            case ObjectType.BookPutaway:
                RemoveFromInventory();
                break;

            case ObjectType.FlagSetup:
                Randomizer barometerInfo = GameObject.FindGameObjectWithTag("barometr").GetComponent<Randomizer>();

                string holdingFlagName = _playerInventory.items[_playerInventory.activeItemID].gameObject.name;
                int holdingFlagId = int.Parse(holdingFlagName.Substring(holdingFlagName.Length - 1));

                // How does it work?
                if (barometerInfo.flagColorID == holdingFlagId)
                {
                    GameObject mainFlag = GameObject.Find("main_flag/Flag");
                    Debug.Log(mainFlag);
                    ColorChange flagMat = new ColorChange(mainFlag, holdingFlagId - 1);

                    RemoveFromInventory();
                }
                break;
            
            default:
                return;
        }
    }

    private void RemoveFromInventory()
    {
        _playerInventory.isFull[_playerInventory.activeItemID] = false;
        _playerInventory.items[_playerInventory.activeItemID].SetActive(false);
        _playerInventory.items[_playerInventory.activeItemID] = null;
        _playerInventory.itemTag[_playerInventory.activeItemID] = "";
        _playerInventory.isActive = false;
    }
}

public enum ObjectType
{
    DoorAnimation,
    BookPutaway,
    FlagSetup
}