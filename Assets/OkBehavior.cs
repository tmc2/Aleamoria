using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OkBehavior : MonoBehaviour
{
    public float showing_time;
    public TMP_Text ok_text;
    //private float timer = 0.0f;
    private float time_left = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (time_left > 0)
        {
            //timer += Time.deltaTime;
            var seconds = Time.deltaTime % 60;

            time_left -= seconds;

            var ok_color = ok_text.color;
            float lerp_transparency = 255 * Mathf.Lerp(0, showing_time, time_left);

            ok_text.color = new Color(ok_color[0], ok_color[1], ok_color[2], lerp_transparency);

            if (time_left <= 0)
            {
                ok_text.enabled = false;
            }
        }
    }

    public void Show()
    {
        ok_text.enabled = true;
        time_left = showing_time;
    }

    public void Reset()
    {
        ok_text.enabled = false;
        time_left = 0.0f;
    }
}
