using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class OkBehavior : MonoBehaviour
{
    public float showing_time;
    public Image ok_text;
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

            // fade effect during the last 20% of showing time
            if (time_left <= 0.2 * showing_time)
            {
                var ok_color = ok_text.color;
                float lerp_transparency = Mathf.InverseLerp(0, 0.2f*showing_time, time_left);

                ok_text.color = new Color(ok_color[0], ok_color[1], ok_color[2], lerp_transparency);
            }

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
        // set transparency back to 1.0f
        var ok_color = ok_text.color;
        ok_text.color = new Color(ok_color[0], ok_color[1], ok_color[2], 1.0f);
    }

    public void Reset()
    {
        ok_text.enabled = false;
        time_left = 0.0f;
    }
}
