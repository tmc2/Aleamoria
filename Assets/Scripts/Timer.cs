using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;

    public TMP_Text time_text;
    public GameHandler game_handler;
    public float time_length;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var time_left = time_length - timer;
        time_text.text = time_left.ToString("0");

        if (time_left <= 0)
        {
            Debug.Log("called endturn()");
            game_handler.EndTurn();
        }
    }

    public void Reset()
    {
        timer = 0.0f;
    }
}
