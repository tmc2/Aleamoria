using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ExplanationVideoBehaviour : MonoBehaviour
{
    public Image background;
    public GameObject rules_screen;
    public GameObject video_screen;
    public GameObject video_overlay;

    void Start()
    {
        rules_screen.SetActive(false);
        background.gameObject.SetActive(false);
        var video_player = GetComponent<VideoPlayer>();
        video_player.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        video_screen.SetActive(false);
        video_overlay.SetActive(false);
        rules_screen.SetActive(true);
    }

}
