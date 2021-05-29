using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningBehaviour : MonoBehaviour
{
    public GameObject menu_screen;
    public Image background;

    public void Finished()
    {
        menu_screen.SetActive(true);
        background.enabled = true;
        this.enabled = false;
    }
}
