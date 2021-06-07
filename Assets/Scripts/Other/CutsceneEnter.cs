using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneImageDisplay;
    public GameObject cutsceneVideoPlayer;
    public GameObject blackScreen;

    public int timeDisplay;


    void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneImageDisplay.SetActive(true);
        cutsceneVideoPlayer.SetActive(true);

        thePlayer.SetActive(false);

        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut() {
        yield return new WaitForSeconds(timeDisplay);
        blackScreen.SetActive(true);
        cutsceneImageDisplay.SetActive(false);
        cutsceneVideoPlayer.SetActive(false);
    }
}
