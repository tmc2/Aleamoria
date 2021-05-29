using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningBehaviour : MonoBehaviour
{
    public void Finished()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
