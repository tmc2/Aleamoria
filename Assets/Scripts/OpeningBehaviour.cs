﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.IO;

public class OpeningBehaviour : MonoBehaviour
{
    // This was used to the animation using several images (spritetile?)
    //public void Finished()
    //{
    //    SceneManager.LoadScene("MenuScene");
    //}


    // Use this when playing a video
    private VideoPlayer video_player;

    //void Start()
    //{
    //    video_player = GetComponent<VideoPlayer>();
    //    //video_player.url = Path.Combine(Application.streamingAssetsPath, "LogoReniewAleamoria.mp4");
    //    video_player.loopPointReached += LoadScene;
    //}

    //void LoadScene(VideoPlayer vp)
    //{
    //    SceneManager.LoadScene("MenuScene");
    //}

    void Start()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = true;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        //videoPlayer.targetCameraAlpha = 0.5F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = "https://cin.ufpe.br/~tmc2/aleamoria/LogoReniewAleamoria.mp4";

        // Skip the first 100 frames.
        //videoPlayer.frame = 100;

        // Restart from beginning when done.
        videoPlayer.isLooping = false;

        // Each time we reach the end, we slow down the playback by a factor of 10.
        videoPlayer.loopPointReached += EndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("MenuScene");
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

}
