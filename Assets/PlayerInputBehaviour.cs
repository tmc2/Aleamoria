using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehaviour : MonoBehaviour
{
    public GameHandler game_handler;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("enter") || Input.GetKeyDown("space") || Input.GetKeyDown("return"))
        {
            game_handler.setPlayers();
        }
    }
}
