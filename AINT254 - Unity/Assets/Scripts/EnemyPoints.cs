using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    public GameObject UI;
    public int Score = 10;

    void Start()
    {
        UI = GameObject.FindWithTag("UI");
    }

    public void SendPoints()
    {
        UI.GetComponent<GameUI>().RecieveScoreAdded(Score);
    }
}
