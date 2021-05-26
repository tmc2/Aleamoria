using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    // Words dataset
    TextAsset text_dataset;

    // Screens
    public GameObject player_input_sc;
    public GameObject instruction_sc;
    public GameObject playing_sc;


    // Player input screen
    public TMP_InputField input_field;
    public TMP_Text warning_text;


    private int players_num = 0;

    public void setPlayers()
    {
        //Debug.Log(input_field.text);
        int parced_num = int.Parse(input_field.text);
        if (parced_num > 0)
        {
            players_num = parced_num;

            // choose the words for this round


            // change screens
            player_input_sc.SetActive(false);
            instruction_sc.SetActive(true);
        } else
        {
            warning_text.gameObject.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
