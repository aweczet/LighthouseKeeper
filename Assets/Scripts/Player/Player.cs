using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Klasa odpowiadająca za wszystkie informacje o graczu
/// </summary>
public class Player : MonoBehaviour
{
    public Quest[] quests;
    public int numberOfActiveQuests;

    public static bool UniqueCollected1 = false;
    public static bool UniqueCollected2 = false;
    public static bool UniqueCollected3 = false;
    public static bool flagMissionCompleted = false;

    private QuestSetup _questSetup;
    private QuestSetup[] questSetups;
    private GameObject _canvas;
    public PlayerInventory playerInventory;

    private LightSwitch _lightSwitch;
    private ColorChange _colorChange;
    private Randomizer _barometr;

    private int _numberOfAllQuestes;
    private int _lighthouseQuestID;
    private int activeQuestID;

    public bool isRetrospection = false;
    public int level;

    public GameObject monologbox;

    private void Awake()
    {
        // Ustawienie UI questów żeby dostosowało się do ilości questów
        level = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        _canvas = GameObject.Find("UICanvas/QuestPanel");
        questSetups = new QuestSetup[quests.Length];
        foreach (Quest quest in quests)
        {
            if (!isRetrospection)
            {
                // Nie testowana zmiana - powinna działać, ale w razie co jest zostawiona w komentarzu niżej wersja, która działa
                _questSetup = new QuestSetup(_canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
                if (!quest.isActive)
                {
                    _questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
                    _lighthouseQuestID = _numberOfAllQuestes;
                }

                quest.questName = _questSetup.newQuestUI.GetComponent<Text>();
                quest.strike = _questSetup.newQuestStrikeUI.GetComponent<Text>();

                if (quest.questGoal.goalType == GoalType.color)
                {
                    Randomizer barometr = GameObject.FindGameObjectWithTag("barometr").GetComponent<Randomizer>();
                    quest.questItem[0] = GameObject.Find("flag_" + barometr.flagColorID);
                    quest.questGoal.goalType = GoalType.collect;
                    quest.questItem[0].GetComponent<ItemPickup>().nonQuestRelated = false;
                    quest.questItem[0].GetComponent<ItemPickup>().itemTag = "flag";
                }

                numberOfActiveQuests += quest.isActive ? 1 : 0;
                _numberOfAllQuestes++;
            }
            else
            {
                questSetups[_numberOfAllQuestes] = new QuestSetup(_canvas, quest.title, quest.questName, quest.strike, _numberOfAllQuestes);
                if (_numberOfAllQuestes == 0)
                {
                    quest.isActive = true;
                    quest.questName = questSetups[_numberOfAllQuestes].newQuestUI.GetComponent<Text>();
                    quest.strike = questSetups[_numberOfAllQuestes].newQuestStrikeUI.GetComponent<Text>();
                    numberOfActiveQuests = 1;
                    activeQuestID = 0;
                }
                else
                {
                    questSetups[_numberOfAllQuestes].newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
                }
                quest.questName = questSetups[_numberOfAllQuestes].newQuestUI.GetComponent<Text>();
                quest.strike = questSetups[_numberOfAllQuestes].newQuestStrikeUI.GetComponent<Text>();
                _numberOfAllQuestes++;
            }
            quest.itemID = new int[quest.questItem.Length];
            quest.questItemLength = quest.questItem.Length;
            Blackout.textbg = monologbox;


            //if (quest.isActive)
            //{
            //    questSetup = new QuestSetup(_canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
            //    quest.questName = questSetup.newQuestUI.GetComponent<Text>();
            //    quest.strike = questSetup.newQuestStrikeUI.GetComponent<Text>();
            //    numberOfActiveQuests += quest.isActive ? 1 : 0;
            //    if (quest.questGoal.goalType == GoalType.color)
            //    {
            //        random barometr = new random();
            //        barometr.liczby();
            //        quest.questGoal.requiredAmmount = barometr.zmienna;
            //    }
            //}
            //else
            //{
            //    questSetup = new QuestSetup(_canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
            //    questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
            //    quest.questName = questSetup.newQuestUI.GetComponent<Text>();
            //    quest.strike = questSetup.newQuestStrikeUI.GetComponent<Text>();
            //    lighthouseQuestID = numberOfAllQuestes;
            //}
            //numberOfAllQuestes++;
        }
        if (!isRetrospection)
        {
           _questSetup.SetCanvasPosition(_canvas, numberOfActiveQuests);
        }
        else
        {
            questSetups[0].SetCanvasPosition(_canvas, numberOfActiveQuests);
        }
        //_questSetup.SetCanvasPosition(__canvas, numberOfActiveQuests);
        playerInventory = GetComponent<PlayerInventory>();

    }
    //         _questSetup.SetCanvasPosition(__canvas, numberOfActiveQuests);
    //         _playerInventory = GetComponent<PlayerInventory>();


    private void Start()
    {
        if (!isRetrospection) return;
        DeleteAllItems();
    }

    private void DeleteAllItems()
    {
        for (int i = 0; i < playerInventory.slots.Length; i++)
        {
            playerInventory.removeItemAfterQuest(i);
        }
    }

    private void Update()
    {
        // W przypadku gdy skończymy wszystkie questy to dodawany jest quest latarni
        if (numberOfActiveQuests == 0)
        {
            if(!isRetrospection)
            {
              quests[_lighthouseQuestID].isActive = true;
              lightHouseQuest();
            }
            else
            {
                if(!quests[_numberOfAllQuestes-1].isCompleted)
                {
                    numberOfActiveQuests = 1;
                    activeQuestID++;
                    quests[activeQuestID].isActive = true;
                    questSetups[activeQuestID].SetCanvasPosition(_canvas, activeQuestID+1);
                    questSetups[activeQuestID].newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0xFF);
                }
            }
        }
    }

    // Używane do questu lokalizacji
    private void OnTriggerEnter(Collider other)
    {
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                foreach (GameObject questItem in quest.questItem)
                {
                    if (other.gameObject == questItem)
                    {
                        quest.questGoal.currentAmmount++;
                        if (quest.questGoal.IsReached())
                        {
                            quest.completed();
                            StartCoroutine(quest.questGoal.showMonolog(monologbox));
                            numberOfActiveQuests--;
                        }

                        Destroy(questItem.transform.parent.gameObject);
                    }
                }
            }
        }
    }

    // Wciśnięcie LPM na zaznaczonym obiekcie
    public void PressedOnSelectable(GameObject item)
    {
        if (item.GetComponent<HarpoonInteraction>() != null)
        {
            item.GetComponent<HarpoonInteraction>().LockIn();
            return;
        }
        if(item.active && item.GetComponent<ItemPickup>() && item.GetComponent<ItemPickup>().nonQuestRelated && !gameObject.GetComponent<PlayerInventory>().isEqFull()){
            item.GetComponent<ItemPickup>().pickUpItem();
            item.SetActive(false);
            return;
        }
        numberOfActiveQuests = 0;
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                numberOfActiveQuests += quest.isActive ? 1 : 0;

                foreach (GameObject questItem in quest.questItem)
                {
                    if (item == questItem)
                    {
                        switch (quest.questGoal.goalType)
                        {
                            case GoalType.press:
                                quest.questGoal.FlipModel(item.transform);
                                // To usuwa obiekt z listy obiektów potrzebnych do questa
                                // Rozwiązuje to problem korzystania z tego samego obiektu w celu wykoania questa
                                // Np. Wciśnij 3 przyciski -> dzięki temu nie można wcisnąć jednego przycisku 3 razy żeby zrobić questa
                                quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                break;
                            case GoalType.collect: case GoalType.color:
                                if (!playerInventory.isEqFull())
                                {
                                    questItem.GetComponent<ItemPickup>().pickUpItem();
                                    questItem.SetActive(false);
                                    quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                    quest.itemID[quest.questGoal.currentAmmount] = gameObject.GetComponent<PlayerInventory>().lastAddedID;
                                }
                                else
                                {
                                    quest.questGoal.currentAmmount--;
                                }

                                break;

                            case GoalType.light:
                            case GoalType.lighthouse:
                                if(!quest.questItem[1].GetComponent<ItemUseOnObject>() || (gameObject.GetComponent<PlayerInventory>().isActive && gameObject.GetComponent<PlayerInventory>().itemTag[gameObject.GetComponent<PlayerInventory>().activeItemID] == quest.questItem[1].GetComponent<ItemUseOnObject>().requiredItemTag))
                                    _lightSwitch = new LightSwitch(quest.questItem[0]);
                                else
                                {
                                    DeleteAllItems();
                                    quest.questGoal.currentAmmount--;
                                }
                                break;

                            // case GoalType.color:
                            //     colorChange = new ColorChange(quest.questItem[0], quest.questGoal.currentAmmount);
                            //     //quest.questGoal.requiredAmmount = barometr.zmienna;
                            //     break;
                            case GoalType.talk:
                                quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                item.GetComponent<RetrospectionTalk>().onMouseDown();
                                // quest.questGoal.currentAmmount--;
                                break;
                            case GoalType.flag:
                                if(!flagMissionCompleted)
                                    quest.questGoal.currentAmmount--;
                                break;
                            default:
                                break;
                        }

                        quest.questGoal.currentAmmount++;

                        if (quest.questGoal.IsReached())
                        {
                            quest.completed();
                            StartCoroutine(quest.questGoal.showMonolog(monologbox));
                            numberOfActiveQuests--;
                        }
                    }
                    else if (item.GetComponent<ItemPickup>() && item.GetComponent<ItemPickup>().nonQuestRelated &&
                             !playerInventory.isEqFull())
                    {
                        questItem.GetComponent<ItemPickup>().pickUpItem();
                        questItem.SetActive(false);
                    }
                }
            }
            else
            {
                foreach (GameObject questItem in quest.questItem)
                {
                    if (item == questItem)
                    {
                        if (quest.questGoal.goalType == GoalType.light)
                            _lightSwitch.toggleLight();
                    }
                }
            }
        }
    }

    // Dodanie questu latarni do listy w ui
    private void lightHouseQuest()
    {
        _questSetup.SetCanvasPosition(_canvas, _numberOfAllQuestes);
        _questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0xFF);
        numberOfActiveQuests++;
    }
}