using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    static private bool firstLoad = true;

    public AudioSource click_sound;

    void Start()
    {
        // see if we need to play the button sound (if we came here from a exit button)
        if (!firstLoad)
        {
            click_sound.Play();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        firstLoad = false;
    }
}