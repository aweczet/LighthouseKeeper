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

    public GameObject uniquepickup;
    public GameObject uniqueobject;
    public static bool collectedUnique = false;

    private QuestSetup questSetup;
    private GameObject canvas;

    private LightSwitch lightSwitch;
    private ColorChange colorChange;
    private random barometr;

    private bool allDone = false;
    private int numberOfAllQuestes;
    private int lighthouseQuestID;

    public int level;
    public Stack<int> loadedLevels;
    [System.NonSerialized]
    private bool initialized;

    private void Init() {
        // Obsługa sceny na której jesteśmy
        loadedLevels = new Stack<int>();
        initialized = true;
    }

    public void addSceneToStack(int buildIndex) {
        if (!initialized) Init();
        // Dodaje scene do Stosu
        loadedLevels.Push(buildIndex);
        level = loadedLevels.Peek();
        Debug.Log("level "+ level);
    }

    void Awake()
    {
        // Ustawienie UI questów żeby dostosowało się do ilości questów
        
        canvas = GameObject.Find("UICanvas/QuestPanel");
        foreach (Quest quest in quests)
        {
            // Nie testowana zmiana - powinna działać, ale w razie co jest zostawiona w komentarzu niżej wersja, która działa
            questSetup = new QuestSetup(canvas, quest.title, quest.questName, quest.strike, numberOfActiveQuests);
            if (!quest.isActive)
            {
                questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0x00);
                lighthouseQuestID = numberOfAllQuestes;
                Debug.Log(quest.questName);
                

            }

            quest.questName = questSetup.newQuestUI.GetComponent<Text>();
            quest.strike = questSetup.newQuestStrikeUI.GetComponent<Text>();

            if (quest.questGoal.goalType == GoalType.color)
            {
                random barometr = GameObject.FindGameObjectWithTag("barometr").GetComponent<random>();
                quest.questGoal.requiredAmmount = barometr.zmienna;
            }

            numberOfActiveQuests += quest.isActive ? 1 : 0;
            numberOfAllQuestes++;

            

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

        if (uniqueobject != null)
            uniqueobject.SetActive(collectedUnique);
        questSetup.SetCanvasPosition(canvas, numberOfActiveQuests);

    }
    private void Update()
    {
        // W przypadku gdy skończymy wszystkie questy to dodawany jest quest latarni
        if(numberOfActiveQuests == 0)
        {
            quests[lighthouseQuestID].isActive = true;
            lightHouseQuest();            
        }
        if (collectedUnique == true && uniqueobject.activeSelf == false)
        {
            uniqueobject.SetActive(true);
        }

        //if (allDone)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    Debug.Log("Quests Completed");
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
        if (item == uniquepickup)
        {
            Destroy(item);
            collectedUnique = true;
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
                                Destroy(questItem);
                                quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                                break;

                            case GoalType.light:
                            case GoalType.lighthouse:
                                lightSwitch = new LightSwitch(quest.questItem[0]);
                                break;

                            case GoalType.color:
                                colorChange = new ColorChange(quest.questItem[0], quest.questGoal.currentAmmount);
                                //quest.questGoal.requiredAmmount = barometr.zmienna;
                                break;

                            default:
                                break;
                        }

                        quest.questGoal.currentAmmount++;

                        if (quest.questGoal.IsReached())
                        {
                            quest.completed();
                            numberOfActiveQuests--;
                        }
                    }
                }

            }
            else
            {
                foreach (GameObject questItem in quest.questItem)
                {
                    if (item == questItem)
                    {
                        if(quest.questGoal.goalType == GoalType.light)
                            lightSwitch.toggleLight();
                    }
                }
            }
        }
    }
    // Dodanie questu latarni do listy w ui
    private void lightHouseQuest()
    {
        questSetup.SetCanvasPosition(canvas, numberOfAllQuestes);
        questSetup.newQuestUI.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0xFF);
        numberOfActiveQuests++;
    }

    public void SavePlayer () {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer () {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        quests = data.quests;
        loadedLevels = data.loadedLevels;

        // numberOfActiveQuests = data.numberOfActiveQuests;
        // uniquepickup = data.uniquepickup;
        // uniqueobject = data.uniqueobject;
        // collectedUnique = data.collectedUnique;
        // questSetup = data.questSetup;
        // canvas = data.canvas;
        // lightSwitch = data.lightSwitch;
        // colorChange = data.colorChange;
        // barometr = data.barometr;
        // allDone = data.allDone;
        // numberOfAllQuestes = data.numberOfAllQuestes;
        // lighthouseQuestID = data.lighthouseQuestID;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
