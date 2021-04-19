using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        LighthouseData data = SaveSystem.LoadGame();
        if (data != null)
        {
            SceneManager.LoadScene(data.sceneId);
            Player.unique_collected_1 = data.uniqueCollected1;
        }
    }
}