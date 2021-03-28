using System.Collections;
using System.Collections.Generic;
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
    private float timeSpeed = .5f; // zmienna wpływająca na prędkość zmiany godziny

    private float maxTime = 6f; // aktualna maksymalna godzina
    private float timeInterval; // interwał czasowy z jakim powinna się zwiększać maksymalna godzina po wykonaniu questa

    private Player player;
    private int numberOfCurrentQuests;
    private bool lastQuest = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // Obliczenie ilość ogólnych questów - liczba aktywnych questów + nieaktywny quest zapalenia latarni
        numberOfCurrentQuests = player.numberOfActiveQuests + 1;
        // Obliczenie o godzin ma się przesunąć czas (w zależności od ilości questów)
        timeInterval = (12f / numberOfCurrentQuests);
        maxTime += timeInterval;
    }

    private void Update()
    {
        // Po wykonaniu wszystkich aktywnych questów, quest "zapal latarnię" staje się aktywny,
        // więc ilość aktywnych questów rośnie o 1
        lastQuest = player.numberOfActiveQuests == numberOfCurrentQuests;
        if (lastQuest)
            numberOfCurrentQuests++;

        // Jeżeli został wykonany quest, przesuń wartość maksymalnej godziny o interwał
        if (player.numberOfActiveQuests + 1 < numberOfCurrentQuests)
        {
            maxTime = maxTime + timeInterval >= 24f ? 23.9f : maxTime + timeInterval;
            numberOfCurrentQuests = player.numberOfActiveQuests + 1;
        }

        // Sprawdzenie czy do światła został dołączony preset
        if (preset == null)
            return;

        // Sprawdza czy aplikacja działa - dzięki temu można (było) zmieniać czas z poziomu sceny, a nie tylko z poziomu gry
        // Aktualnie to nie działa, ze względu na ograniczenia maxTime
        if (Application.isPlaying)
        {
            // Sprawdza czy aktualna godzina jest mniejsza od (aktualnie) maksymalnej godziny
            // Jeżeli tak, to dodaje do czasu wartość czasu spędzonego w grze
            if(timeOfDay < maxTime )
            {
                timeOfDay += Time.deltaTime / timeSpeed;
                timeOfDay %= 24;

                // Dla testu czy czas działa poprawnie
                if ((timeOfDay / 24f) == .04)
                    Debug.Log("1 am");
                UpdateLighting(timeOfDay / 24f);
            }
            if (SceneManager.GetActiveScene().name == "MenuFloating")
            {
                maxTime = 24;
                if (timeOfDay < 5 || timeOfDay > 19)
                    timeOfDay = 5;
            }
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }
    
    // Metoda obsługująca obracanie się światła i ustawienie kolorów
    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);
        RenderSettings.skybox.SetColor("_Tint", preset.SkyboxColor.Evaluate(timePercent));

        // Jeżeli mamy ustawione światło to ustawiamy jego światło i rotację - prawdopodobnie można naprawić
        // problem powstawania długich cieni poprzez obcięcie wartości obrotu ?
        if (directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);

            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }
}