using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadMenuAfterCutscene : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += CutsceneEnd;
    }

    private void CutsceneEnd(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene(0);
    }
}
