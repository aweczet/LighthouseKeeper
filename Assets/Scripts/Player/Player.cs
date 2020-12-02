using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Klasa odpowiadająca za wszystkie informacje o graczu
/// </summary>


public class Player : MonoBehaviour
{
    public Quest[] quests;
    public int numberOfActiveQuests;

    private QuestSetup questSetup;
    private GameObject canvas;

    private LightSwitch lightSwitch;
    private ColorChange colorChange;
    private random barometr;

    private bool allDone = false;
    private int numberOfAllQuestes;
    private int lighthouseQuestID;

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
            }

            quest.questName = questSetup.newQuestUI.GetComponent<Text>();
            quest.strike = questSetup.newQuestStrikeUI.GetComponent<Text>();

            if (quest.questGoal.goalType == GoalType.color)
            {
                random barometr = new random();
                barometr.liczby();
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
}
