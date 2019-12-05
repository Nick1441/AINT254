using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    //Player/Distance
    public GameObject Player;
    public float Distance;
    public float Range = 10;

    //CHALLENGES
    public GameObject LavaJumpSingleL;
    public GameObject LavaJumpSingleR;

    public GameObject LavaJumpDoubL;
    public GameObject LavaJumpDoubR;

    public GameObject LavaJumpTripL;
    public GameObject LavaJumpTripR;

    public GameObject EnemyAttack;

    public GameObject TrainDodge;
    public GameObject Spawner;

    //CHANCE FOR EACH CHALLENGE
    public int Chance;
    public int NextSpawnerDis;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        Distance = Vector3.Distance(Player.transform.position, transform.position);

        if (Distance <= Range)
        {
            Chance = Random.Range(0, 100);

            //Jump L Single
            if (Chance <= 10)
            {
                GameObject Challenge1 = Instantiate(LavaJumpSingleL, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }
            //Jump R Single
            else if (Chance > 10 && Chance <= 20)
            {
                GameObject Challenge1 = Instantiate(LavaJumpSingleR, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }
            //Jump L Double
            else if (Chance > 20 && Chance <= 30)
            {
                GameObject Challenge1 = Instantiate(LavaJumpDoubL, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 3;
            }
            //Jump R Double
            else if (Chance > 30 && Chance <= 40)
            {
                GameObject Challenge1 = Instantiate(LavaJumpDoubR, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 3;
            }
            //Jump L Triple
            else if (Chance > 40 && Chance <= 50)
            {
                GameObject Challenge1 = Instantiate(LavaJumpTripL, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 4;
            }
            //Jump R Triple
            else if (Chance > 50 && Chance <= 60)
            {
                GameObject Challenge1 = Instantiate(LavaJumpTripR, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 4;
            }
            //Enemy Spawn
            else if (Chance > 60 && Chance <= 80)
            {
                GameObject Challenge1 = Instantiate(EnemyAttack, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }
            //Train Spawn
            else
            {
                GameObject Challenge2 = Instantiate(TrainDodge, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }

            Vector3 NextSpawner = new Vector3(transform.position.x, transform.position.y, transform.position.z + NextSpawnerDis);
            GameObject NextSpawn = Instantiate(Spawner, NextSpawner, transform.rotation) as GameObject;

            Destroy(this.gameObject);
        }
    }



}
