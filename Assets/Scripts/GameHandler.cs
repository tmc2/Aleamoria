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
    public GameObject round_sc;
    public GameObject playing_sc;


    // Player input screen 
    public TMP_InputField input_field;
    public TMP_Text warning_text;

    // Instruction screen
    public TMP_Text instruction_text;
    public TMP_Text Team_text;

    // Playing screen
    public TMP_Text time;
    public TMP_Text team1_score_text;
    public TMP_Text team2_score_text;
    public TMP_Text aleamoria_text;

    // private variables
    private int players_num = 0;
    private List<string> full_dataset;
    private List<string> current_dataset;
    private int current_idx = 0;
    private int round = 1;
    private int team1_score = 0;
    private int team2_score = 0;
    private bool team1_is_playing = true;

    public void setPlayers()
    {
        //Debug.Log(input_field.text);
        int parced_num = int.Parse(input_field.text);
        if (parced_num > 0)
        {
            players_num = parced_num;

            // choose the words for this round
            ChooseWords();

            // change screens
            player_input_sc.SetActive(false);
            instruction_sc.SetActive(true);
        } else
        {
            warning_text.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        instruction_sc.SetActive(false);
        GetNextWord();
        playing_sc.SetActive(true);
    }

    public void GetNextWord()
    {
        if (current_idx < current_dataset.Count)
        {
            aleamoria_text.text = current_dataset[current_idx];
            current_idx += 1;
        } else
        {
            PrepareNextRound();
        }

    }

    public void AddScore()
    {
        if (team1_is_playing)
        {
            team1_score += 1;
            team1_score_text.text = team1_score.ToString();
        } else
        {
            team2_score += 1;
            team2_score_text.text = team2_score.ToString();
        }
    }

    private void PrepareNextRound()
    {

    }

    public void GoToRoundScreen()
    {
        instruction_sc.SetActive(false);
        round_sc.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void BackToPlayersNum()
    {
        instruction_sc.SetActive(false);
        round_sc.SetActive(false);
    }

    public void BackToinstruction()
    {
        round_sc.SetActive(false);
        player_input_sc.SetActive(true);
    }

    private void ChooseWords()
    {
        // randomly get the apropriate ammount of words from the dataset
        List<string> temp_list = new System.Collections.Generic.List<string>();
        temp_list.Add("Pudim1");
        temp_list.Add("Pudim2");
        temp_list.Add("Pudim3");

        // shuffling the entries
        //Random rng = new Random();
        //current_dataset = temp_list.OrderBy(a => rng.Next()).ToList();
        current_dataset = temp_list;
    }
}
