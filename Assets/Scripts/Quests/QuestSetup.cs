using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa odpowiadajca za inicjalizację UI związanego z questami
/// Wszystko jest robione podwójnie dlatego, że u nas skreślenie (po wykoaniu) questa
/// polega na wyświetleniu na nazwie questa, obiektu tekstowego zaiwerającego podkreślniki
/// </summary>

public class QuestSetup
{
    public GameObject newQuestUI;
    public GameObject newQuestStrikeUI;

    public QuestSetup(GameObject canvas, string title, Text file, Text strike, int id)
    {
        this.newQuestUI = new GameObject(title);
        this.newQuestStrikeUI = new GameObject(title + "_strike");

        newQuestUI.transform.parent = canvas.transform;
        newQuestUI.layer = canvas.layer;
        newQuestStrikeUI.transform.parent = canvas.transform;
        newQuestStrikeUI.layer = canvas.layer;
        QuestUI(newQuestUI, newQuestStrikeUI, title, file, strike, id);
    }

    public void SetCanvasPosition(GameObject canvas, int numberOfActiveQuests)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        canvasRect.anchorMin = new Vector2(1, 1);
        canvasRect.anchorMax = new Vector2(1, 1);
        canvasRect.localScale = new Vector3(1, 1, 1);

        canvasRect.sizeDelta = new Vector2(200, 20 * numberOfActiveQuests + 8);
        canvasRect.anchoredPosition = new Vector2(-100, (-(20 * numberOfActiveQuests) - 10) / 2);
    }
    void SetPosition(RectTransform r, int id, bool isStrike = false)
    {
        r.anchorMin = new Vector2(1, 1);
        r.anchorMax = new Vector2(1, 1);
        r.localScale = new Vector3(1, 1, 1);

        r.sizeDelta = new Vector2(200, 30);

        if (isStrike)
            r.anchoredPosition = new Vector2(-90, -15 - id * 20);
        else
            r.anchoredPosition = new Vector2(-90, -20 - id * 20);
    }

    void QuestUI(GameObject questObject, GameObject strikeObject, string title, Text file, Text strike, int id)
    {
        Font font = Resources.Load("roboto_bold") as Font;

        questObject.AddComponent<RectTransform>();
        strikeObject.AddComponent<RectTransform>();

        RectTransform questRect = questObject.GetComponent<RectTransform>();
        RectTransform strikeRect = strikeObject.GetComponent<RectTransform>();

        SetPosition(questRect, id);
        SetPosition(strikeRect, id, true);

        questObject.AddComponent<Text>();
        strikeObject.AddComponent<Text>();

        questObject.GetComponent<Text>().font = font;
        strikeObject.GetComponent<Text>().font = font;

        questObject.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0xFF);
        strikeObject.GetComponent<Text>().color = new Color32(0x33, 0x33, 0x33, 0xFF);

        file = questObject.GetComponent<Text>();
        strike = strikeObject.GetComponent<Text>();

        file.text = title;
        strike.text = "";
    }
}
