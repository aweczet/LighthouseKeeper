using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shark_collision : MonoBehaviour
{
    private int _sharkHealth;
    public int _sharkMaxHealth = 100;
    public int _harpoonDamage;
    int nextScene;
    

    public GameObject _sharkHealthBarUI;
    public Slider _sharkHealthBar;

    private void Start()
    {
        _sharkHealth = _sharkMaxHealth;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("harpoon")) return;
        _sharkHealth -= _harpoonDamage;
        _sharkHealthBar.value = _sharkHealth;
        Debug.Log("hit detected " + _sharkHealth);
    }

    private void Update()
    {
        if (_sharkHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(_sharkHealthBarUI);
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
    }
}
