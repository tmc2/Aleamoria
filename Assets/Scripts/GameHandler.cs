using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private int playersNum = 0;

    public void setPlayers(int i)
    {
        playersNum = i;
    }
}
