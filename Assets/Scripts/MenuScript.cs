using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    //public void QuitGame()
    //{
    //    Debug.Log("Quit!!");
    //    Application.Quit();
    //}

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
