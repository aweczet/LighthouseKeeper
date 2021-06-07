using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadScene();
    }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        LighthouseData data = SaveSystem.LoadGame();
        if (data == null) return;
        SceneManager.LoadScene(data.sceneId);
    }

    // TODO: change position of item after load
    private void LoadScene()
    {
        LighthouseData data = SaveSystem.LoadGame();
        if (data == null || data.sceneId != SceneManager.GetActiveScene().buildIndex) return;
        Player.UniqueCollected1 = data.uniqueCollected1;
        Player.UniqueCollected2 = data.uniqueCollected2;

        Transform inventoryImages = GameObject.Find("UICanvas/Inventory").transform;
        Transform inventoryObjects = GameObject.Find("First Person Player/HeldItem").transform;
        
        Debug.Log("Load scene");

        foreach (var itemName in data.itemNames)
        {
            Debug.Log("Item: " + itemName);
            GameObject item = Instantiate(Resources.Load("Items/" + itemName + "_obj"), inventoryObjects, false) as GameObject;
            GameObject itemImg = Instantiate(Resources.Load("Items/" + itemName + "_img"), inventoryImages, false) as GameObject;
            
            item.name = itemName;
            itemImg.name = itemName;

            ItemPickup itemPickup = item.GetComponent<ItemPickup>();
            itemPickup.Start();
            itemPickup.itemButton = itemImg;
            itemPickup.pickUpItem();
        }
    }
}