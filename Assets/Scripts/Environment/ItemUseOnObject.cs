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
                _playerInventory.removeItemAfterQuest(_playerInventory.activeItemID);
                break;

            case ObjectType.FlagSetup:
                Randomizer barometerInfo = GameObject.FindGameObjectWithTag("barometr").GetComponent<Randomizer>();

                string holdingFlagName = _playerInventory.items[_playerInventory.activeItemID].gameObject.name;
                int holdingFlagId = int.Parse(holdingFlagName.Substring(holdingFlagName.Length - 1));

                // How does it work?
                if (barometerInfo.flagColorID == holdingFlagId && _playerInventory.isActive)
                {
                    Player.flagMissionCompleted = true;
                    GameObject mainFlag = GameObject.Find("main_flag/Flag");
                    ColorChange flagMat = new ColorChange(mainFlag, holdingFlagId - 1);

                    _playerInventory.removeItemAfterQuest(_playerInventory.activeItemID);
                }
                break;
            case ObjectType.TagPlaceholder:
                return;
                break;

            default:
                return;
        }
    }
}

public enum ObjectType
{
    DoorAnimation,
    BookPutaway,
    FlagSetup,
    TagPlaceholder
}