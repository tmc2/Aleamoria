using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    // Words dataset
    TextAsset text_dataset;

    // Outsider object scripts
    public Timer timer;

    // Screens
    public GameObject player_input_sc;
    public GameObject instruction_sc;
    public GameObject round_sc;
    public GameObject playing_sc;


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
        "Nessa rodada o líder precisa fazer sua equipe adivinhar a Aleamória apenas através de sons inteligíveis. Cuidado para não dar dicas de nenhuma outra forma!"};

    public void setPlayers()
    {
        //Debug.Log(input_field.text);
        int parced_num = int.Parse(input_field.text);
        if (parced_num > 0)
        {
            players_num = parced_num;

            // choose the words for this game
            ChooseWords();

            // change screens
            player_input_sc.SetActive(false);
            round_text.text = "FASE " + (round + 1).ToString();
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
        // scramble the words and reset pointer
        //TODO: scramble
        current_idx = 0;
        round += 1;
        if(round < 4)
        {
            // change the instruction text
            round_text.text = "FASE " + (round + 1).ToString();
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
            // TODO: go to ending screen!!
            Debug.Log("ACABOU!!");
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

    //public void BackToinstruction()
    //{
    //    round_sc.SetActive(false);
    //    instruction_sc.SetActive(true);
    //}

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
