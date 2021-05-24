using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneImageDisplay;
    public GameObject cutsceneVideoPlayer;

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
        thePlayer.SetActive(true);
        cutsceneImageDisplay.SetActive(false);
        cutsceneVideoPlayer.SetActive(false);
    }
}
