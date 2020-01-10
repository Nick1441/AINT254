using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    public GameObject UI;
    public int Score = 10;

    //Simple Script for sending points of objects.
    void Start()
    {
        UI = GameObject.FindWithTag("UI");
    }

    public void SendPoints()
    {
        UI.GetComponent<GameUI>().RecieveScoreAdded(Score);
    }
}
