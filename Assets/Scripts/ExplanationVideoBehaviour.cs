using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ExplanationVideoBehaviour : MonoBehaviour
{
    public GameObject rules_screen;
    public GameObject video_screen;

    void Start()
    {
        rules_screen.SetActive(false);
        var video_player = GetComponent<VideoPlayer>();
        video_player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        video_screen.SetActive(false);
        rules_screen.SetActive(true);
    }

}
