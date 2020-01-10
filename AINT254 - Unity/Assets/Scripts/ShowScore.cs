using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text ScoreText;

    //Displays score when the game is over. useses Player Prefs to store score.
    //Sets overall Score to Overall Score text.
    void Start()
    {
        string OverallScore;
        OverallScore = PlayerPrefs.GetString("Player Score");
        ScoreText.text = OverallScore;
    }
}
