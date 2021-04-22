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
    // public Vector3 playerPosition;

    public Quest[] quests;
    public int numberOfActiveQuests;

    public static bool UniqueCollected1 = false;
    public static bool UniqueCollected2 = false;
    public static bool UniqueCollected3 = false;

    private QuestSetup _questSetup;
    private GameObject _canvas;
    private PlayerInventory _playerInventory;

    private LightSwitch _lightSwitch;
    private ColorChange _colorChange;
    private Randomizer _barometr;

    // private bool _allDone = false;
    private int _numberOfAllQuestes;
    private int _lighthouseQuestID;

    public int level;

    // public Stack<int> loadedLevels;
    public GameObject monologbox;
    // [System.NonSerialized]
    // private bool initialized;


    // private void Init() {
    //     // Obsługa sceny na której jesteśmy
    //     loadedLevels = new Stack<int>();
    //     initialized = true;
    // }
    //
    // public void addSceneToStack(int buildIndex) {
    //     if (!initialized) Init();
    //     // Dodaje scene do Stosu
    //     loadedLevels.Push(buildIndex);
    //     level = loadedLevels.Peek();
    //     Debug.Log("added level " + level);
    // }

    // public void StrikeAllInactiveQuests()
    // {
    //     foreach (Quest quest in quests)
    //     {
    //         if (quest.questGoal.goalType != GoalType.lighthouse)
    //         {
    //             quest.StrikeQuest();
    //         }
    //     }
    // }

    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
        // Ustawienie UI questów żeby dostosowało się do ilości questów
        _canvas = GameObject.Find("UICanvas/QuestPanel");
        foreach (Quest quest in quests)
        {
            // Nie testowana zmiana - powinna działać, ale w razie co jest zostawiona w komentarzu niżej wersja, która działa
            _questSetup = new QuestSetup(_canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
            if (!quest.isActive)
            {
                _questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
                _lighthouseQuestID = _numberOfAllQuestes;
                // Debug.Log(quest.questName);
            }

            quest.questName = _questSetup.newQuestUI.GetComponent<Text>();
            quest.strike = _questSetup.newQuestStrikeUI.GetComponent<Text>();

            if (quest.questGoal.goalType == GoalType.color)
            {
                Randomizer barometr = GameObject.FindGameObjectWithTag("barometr").GetComponent<Randomizer>();
                quest.questGoal.requiredAmmount = barometr.flagColorID;
            }

            numberOfActiveQuests += quest.isActive ? 1 : 0;
            _numberOfAllQuestes++;

            //if (quest.isActive)
            //{
            //    questSetup = new QuestSetup(canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
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
            //    questSetup = new QuestSetup(canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
            //    questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
            //    quest.questName = questSetup.newQuestUI.GetComponent<Text>();
            //    quest.strike = questSetup.newQuestStrikeUI.GetComponent<Text>();
            //    lighthouseQuestID = numberOfAllQuestes;
            //}
            //numberOfAllQuestes++;
        }

        _questSetup.SetCanvasPosition(_canvas, numberOfActiveQuests);
        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        // W przypadku gdy skończymy wszystkie questy to dodawany jest quest latarni
        if (numberOfActiveQuests == 0)
        {
            quests[_lighthouseQuestID].isActive = true;
            lightHouseQuest();
        }
        //if (allDone)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    Debug.Log("Quests Completed");
        //}

        //if (Input.GetKeyDown(KeyCode.Escape)) {
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Menu
        //}
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
            item.GetComponent<HarpoonInteraction>().Shoot();
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
                            case GoalType.collect:
                                if (!_playerInventory.isEqFull())
                                {
                                    Destroy(questItem);
                                    quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                }
                                else
                                {
                                    quest.questGoal.currentAmmount--;
                                }

                                break;

                            case GoalType.light:
                            case GoalType.lighthouse:
                                _lightSwitch = new LightSwitch(quest.questItem[0]);
                                break;

                            // case GoalType.color:
                            //     colorChange = new ColorChange(quest.questItem[0], quest.questGoal.currentAmmount);
                            //     //quest.questGoal.requiredAmmount = barometr.zmienna;
                            //     break;
                            case GoalType.talk:
                                quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                item.GetComponent<RetrospectionTalk>().onMouseDown();
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
                             !_playerInventory.isEqFull())
                    {
                        Destroy(item);
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

    // public void SavePlayer () {
    //     SaveSystem.SavePlayer(this);
    // }
    //
    // public void LoadPlayer () {
    //     PlayerData data = SaveSystem.LoadPlayer();
    //     level = data.level;
    //     quests = data.quests;
    //     loadedLevels = data.loadedLevels;
    //
    //     // numberOfActiveQuests = data.numberOfActiveQuests;
    //     // uniquepickup = data.uniquepickup;
    //     // uniqueobject = data.uniqueobject;
    //     // collectedUnique = data.collectedUnique;
    //     // questSetup = data.questSetup;
    //     // canvas = data.canvas;
    //     // lightSwitch = data.lightSwitch;
    //     // colorChange = data.colorChange;
    //     // barometr = data.barometr;
    //     // allDone = data.allDone;
    //     // numberOfAllQuestes = data.numberOfAllQuestes;
    //     // lighthouseQuestID = data.lighthouseQuestID;
    //
    //     Vector3 position;
    //     position.x = data.position[0];
    //     position.y = data.position[1];
    //     position.z = data.position[2];
    //     transform.position = position;
    //
    //     Debug.Log("level load " + level);
    //     SceneManager.LoadScene(level);
    // }
}