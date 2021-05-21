using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Klasa zarządzająca oświetleniem. Odpowiada za przesuwanie się słońca (w zależności od czasu) i korygowanie oświetlenia
/// </summary>
[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private Lightingpreset preset;

    [SerializeField, Range(0, 24)] private float timeOfDay; // aktualna godzina
    private float _timeSpeed = .5f; // zmienna wpływająca na prędkość zmiany godziny

    private float _maxTime = 6f; // aktualna maksymalna godzina

    private float
        _timeInterval; // interwał czasowy z jakim powinna się zwiększać maksymalna godzina po wykonaniu questa

    private Player _player;
    private int _numberOfCurrentQuests;
    private bool _lastQuest = false;

    public GameObject lighthouse;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // Obliczenie ilość ogólnych questów - liczba aktywnych questów + nieaktywny quest zapalenia latarni
        _numberOfCurrentQuests = _player.numberOfActiveQuests + 1;
        // Obliczenie o godzin ma się przesunąć czas (w zależności od ilości questów)
        _timeInterval = (12f / _numberOfCurrentQuests);
        _maxTime += _timeInterval;
        Debug.LogWarning(_maxTime);
    }

    private void Update()
    {
        // Sprawdzenie czy do światła został dołączony preset
        if (preset == null)
            return;

        // Checks if all quests are done
        _lastQuest = _player.numberOfActiveQuests == _numberOfCurrentQuests;

        AddLastQuest();

        SetMaxTime();

        if (Application.isPlaying)
            AddTime();
    }

    // Adds last quest after finishing all active quests
    private void AddLastQuest()
    {
        // Po wykonaniu wszystkich aktywnych questów, quest "zapal latarnię" staje się aktywny,
        // więc ilość aktywnych questów rośnie o 1
        if (_lastQuest)
            _numberOfCurrentQuests++;
    }

    // Sets new max time depending on quests
    private void SetMaxTime()
    {
        // Jeżeli został wykonany quest, przesuń wartość maksymalnej godziny o interwał
        if (_player.numberOfActiveQuests + 1 >= _numberOfCurrentQuests)
            return;
        _maxTime = _maxTime + _timeInterval >= 24f ? 23.9f : _maxTime + _timeInterval;
        _numberOfCurrentQuests = _player.numberOfActiveQuests + 1;
    }

    // Adds time if needed 
    private void AddTime()
    {
        SetTimeOnMenu();
        // Sprawdza czy aktualna godzina jest mniejsza od (aktualnie) maksymalnej godziny
        // Jeżeli tak, to dodaje do czasu wartość czasu spędzonego w grze
        if (!(timeOfDay < _maxTime))
            return;
        timeOfDay += Time.deltaTime / _timeSpeed;
        timeOfDay %= 24;

        UpdateLighting(timeOfDay / 24f);
    }

    // Sets max time independently of quests in floating menu
    private void SetTimeOnMenu()
    {
        if (SceneManager.GetActiveScene().name != "MenuFloating" && SceneManager.GetActiveScene().name != "MenuFloatingWithBackground")
            return;
        _maxTime = 12;
        if (timeOfDay < 6 || timeOfDay > 18)
            lighthouse.SetActive(true);
        else
            lighthouse.SetActive(false);
    }

    // Metoda obsługująca obracanie się światła i ustawienie kolorów
    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);
        RenderSettings.skybox.SetColor("_Tint", preset.skyboxColor.Evaluate(timePercent));

        // Jeżeli mamy ustawione światło to ustawiamy jego światło i rotację - prawdopodobnie można naprawić
        // problem powstawania długich cieni poprzez obcięcie wartości obrotu ?
        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);

            directionalLight.transform.localRotation =
                Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
}