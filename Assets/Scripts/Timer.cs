using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    private float countdown = 0.0f;

    public TMP_Text time_text;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        countdown = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var seconds = timer % 60;

        time_text.text = (countdown - seconds).ToString("0.0");
    }
}
