using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    //private float countdown = 0.0f;

    public TMP_Text time_text;
    public GameHandler game_handler;
    public float time_length;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    timer = 0.0f;
    //    countdown = 60.0f;
    //}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var seconds = timer % 60;

        var time_left = time_length - seconds;
        time_text.text = time_left.ToString("0");

        if (time_left <= 0)
        {
            game_handler.EndTurn();
        }
    }

    public void Reset()
    {
        timer = 0.0f;
        //countdown = 60.0f;
    }
}
