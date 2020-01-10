using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//Edited From First Years Version.
[System.Serializable]
public struct HighScores
{
    public List<int> scores;
}

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    public HighScores highScore;
    private int totalHighScores = 5;

    //Getting the player prefs set at the end of the arcade mode.
    public void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        string s = PlayerPrefs.GetString("HighScores");

        //checking fdor highscores already entered.
        if (string.IsNullOrEmpty(s))
        {
            highScore = new HighScores();
            highScore.scores = new List<int>();
        }
        else
        {
            highScore = JsonUtility.FromJson<HighScores>(s);
        }

        //Organising Highscores into order.
        if (highScore.scores.Count < totalHighScores)
        {
            int amount = totalHighScores - highScore.scores.Count;
            for (int i = 0; i < amount; i++)
            {
                highScore.scores.Add(0);
            }
        }

        //Putting highscore into correct place.
        if (score > highScore.scores[totalHighScores - 1])
        {
            highScore.scores[totalHighScores - 1] = score;
        }

        highScore.scores.Sort();
        highScore.scores.Reverse(0, totalHighScores);

        highScoreText.text = "";

        for (int i = 0; i < totalHighScores; i++)
        {
            if (highScore.scores[i] == score)
            {
                highScoreText.text += "<color=#ffa411>" + (i + 1).ToString() + ". " + highScore.scores[i].ToString() + "</color>\n";
            }
            else
            {
                highScoreText.text += (i + 1).ToString() + ". " + highScore.scores[i].ToString() + "\n";
            }
        }

        //Setting the JSON file with all highscore entered.
        string scoresJSON = JsonUtility.ToJson(highScore);
        PlayerPrefs.SetString("HighScores", scoresJSON);
    }
}
