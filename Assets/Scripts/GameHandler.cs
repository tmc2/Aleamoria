using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Linq;
using System;

public class GameHandler : MonoBehaviour
{
    // Words dataset
    public TextAsset text_dataset;

    // Outsider object scripts
    public Timer timer;

    // Screens
    public GameObject player_input_sc;
    public GameObject instruction_sc;
    public GameObject round_sc;
    public GameObject playing_sc;
    public GameObject win_sc;


    // Player input screen 
    public TMP_InputField input_field;
    public TMP_Text warning_text;

    // Instruction screen
    public TMP_Text round_text;
    public TMP_Text instruction_text;

    // turn screen
    public TMP_Text Team_text;

    // Playing screen
    public TMP_Text time;
    public TMP_Text team1_score_text;
    public TMP_Text team2_score_text;
    public TMP_Text aleamoria_text;
    public OkBehavior ok_text;

    // Winner screen
    public TMP_Text sentence_text;
    public TMP_Text winner_text;
    public TMP_Text winner_score;
    public TMP_Text loser_score;
    public Canvas team1_canvas;
    public Canvas team2_canvas;

    // private variables
    private int players_num = 0;
    private List<string> full_dataset;
    private List<string> current_dataset;
    private int current_idx = 0;
    private int team1_score = 0;
    private int team2_score = 0;
    private bool team1_is_playing = true;
    private int round = 0;
    private List<string> round_explanations = new List<string> { 
        "Nessa rodada o líder precisa fazer sua equipe adivinhar a Aleamória descrevendo-a verbalmente. Cuidado para não falar palavras contidas na Aleamória!",
        "Nessa rodada o líder precisa fazer sua equipe adivinhar a Aleamória através de mímica. Cuidado para não emitir nenhum som!",
        "Nessa rodada o líder precisa fazer sua equipe adivinhar a Aleamória através de uma única palavra. É só UMA mesmo, ok?!",
        "Nessa rodada o líder precisa fazer sua equipe adivinhar a Aleamória apenas através de sons vocais não-verbais. Cuidado para não dar dicas de nenhuma outra forma!"};
    private List<string> round_titles = new List<string>
    {
        "FASE 1: DESCRIÇÃO VERBAL",
        "FASE 2: MÍMICA",
        "FASE 3: UMA PALAVRA",
        "FASE 4: SONS"
    };

    void Start()
    {
        string[] linesFromfile = text_dataset.text.Split("\n"[0]);
        full_dataset = new List<string>();
        foreach (var line in linesFromfile)
        {
            full_dataset.Add(line);
        }
    }

    public void setPlayers()
    {
        //Debug.Log(input_field.text);
        int parced_num = int.Parse(input_field.text);
        if (parced_num >= 4)
        {
            players_num = parced_num;

            // choose the words for this game
            ChooseWords();

            // change screens
            player_input_sc.SetActive(false);
            round_text.text = round_titles[round];
            instruction_text.text = round_explanations[round];
            instruction_sc.SetActive(true);
        } else
        {
            warning_text.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        round_sc.SetActive(false);
        aleamoria_text.text = current_dataset[current_idx];
        timer.Reset();
        playing_sc.SetActive(true);
    }

    public void GetNextWord()
    {
        current_idx += 1;
        if (current_idx < current_dataset.Count)
        {
            aleamoria_text.text = current_dataset[current_idx];
        } else
        {
            PrepareNextRound();
        }

    }

    public void AddScore()
    {
        ok_text.Show();
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
        playing_sc.SetActive(false);
        ok_text.Reset();
        // scramble the words and reset pointer
        //TODO: scramble
        current_dataset = current_dataset.OrderBy(a => Guid.NewGuid()).ToList();
        current_idx = 0;
        round += 1;
        if(round < 4)
        {
            // change the instruction text
            round_text.text = round_titles[round];
            instruction_text.text = round_explanations[round];

            // switch playing team
            team1_is_playing = !team1_is_playing;
            // update text
            if (team1_is_playing)
            {
                Team_text.text = "É a vez da Equipe Vermelha!";
            }
            else
            {
                Team_text.text = "É a vez da Equipe Amarela!";
            }

            // show new instruction screen
            instruction_sc.SetActive(true);
        } else
        {
            win_sc.SetActive(true);
            if (team1_score == team2_score)
            {
                sentence_text.text = "";
                winner_text.text = "EMPATE";
                winner_score.text = team1_score.ToString();
                loser_score.text = team2_score.ToString();
                team1_canvas.enabled = true;
                team2_canvas.enabled = true;
            } else if (team1_score > team2_score)
            {
                winner_text.text = "VERMELHA";
                winner_score.text = team1_score.ToString();
                loser_score.text = team2_score.ToString();
                team1_canvas.enabled = true;
                team2_canvas.enabled = false;
            } else
            {
                winner_text.text = "AMARELA";
                winner_score.text = team2_score.ToString();
                loser_score.text = team1_score.ToString();
                team1_canvas.enabled = false;
                team2_canvas.enabled = true;
            }
        }

    }

    public void EndTurn()
    {
        // change team
        team1_is_playing = !team1_is_playing;
        // update text
        if (team1_is_playing)
        {
            Team_text.text = "É a vez da Equipe Vermelha!";
        } else {
            Team_text.text = "É a vez da Equipe Amarela!";
        }

        // switch screen
        playing_sc.SetActive(false);
        round_sc.SetActive(true);
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
        player_input_sc.SetActive(true);
    }


    private void ChooseWords()
    {
        // randomly get the apropriate ammount of words from the dataset
        current_dataset = new System.Collections.Generic.List<string>();
        int length = players_num * 3;
        if (length > full_dataset.Count)
        {
            length = full_dataset.Count;
        }

        List<int>  numbers_list = new List<int>(new int[length]);
        for (int i = 0; i < length; i++)
        {
            int random_pos = UnityEngine.Random.Range(0, full_dataset.Count - 1);
            while(numbers_list.Contains(random_pos)) // TODO: WARNING! This could lead to livelock if the number of aleamorias to choose is greater than the dataset
            {
                random_pos = UnityEngine.Random.Range(0, full_dataset.Count - 1);
            }
            numbers_list.Add(random_pos);
            current_dataset.Add(full_dataset[random_pos]);
        }
    }
}
