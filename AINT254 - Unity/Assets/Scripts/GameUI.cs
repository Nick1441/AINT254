using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //POINTS
    //Gets Objects Position, Each "Jump" Foward is the Score Points
    //Players Gap is How Far Forward the Start From 0 On Z.
    public int StartingGap = 3;
    public GameObject Player;
    public Text ScorePoints;
    private Vector3 PlayerStart;
    public int Score;
    public int EnemyPoints = 0;

    //HEALTH SYSTEM
    public Slider HealthBar;
    // Start is called before the first frame update

    public void UpdateHealthbar(int Health)
    {
        HealthBar.value = Health;
    }

    void Start()
    {
        PlayerStart = Player.transform.position;
        Score = (int)PlayerStart.z - (StartingGap + 1);
    }

    void Update()
    {
        Score =  ((int)Player.transform.position.z - (StartingGap + 1)) + EnemyPoints;
        ScorePoints.text = "SCORE - " + Score.ToString();
    }

    public void RecieveScoreAdded(int Score)
    {
        EnemyPoints = EnemyPoints + Score;
    }

    public void FixedUpdate()
    {
        PlayerPrefs.SetString("Player Score", ScorePoints.text);
        PlayerPrefs.SetInt("Score", Score);
    }
}
