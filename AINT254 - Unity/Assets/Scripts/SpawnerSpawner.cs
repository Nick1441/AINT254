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
    public GameObject LavaJump;
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

            //LAVA JUMP
            if (Chance < 50)
            {
                GameObject Challenge1 = Instantiate(LavaJump, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }
            //TRAIN HIT
            else
            {
                GameObject Challenge2 = Instantiate(TrainDodge, transform.position, transform.rotation) as GameObject;
                NextSpawnerDis = 2;
            }

            Vector3 NextSpawner = new Vector3(transform.position.x, transform.position.y, transform.position.z + NextSpawnerDis);
            GameObject NextSpawn = Instantiate(Spawner, NextSpawner, transform.rotation) as GameObject;

            Destroy(this);
        }





        //Chance = Random.Range(0, 100);

        //IF LAVA JUMP Move NExt Spawner 2 Down Then Redo This. Remake Spawner Ever 2 Spots
        //Make Tripple Layer Lava Jumpers Etc.


        //LAVA JUMP - Single
        //GameObject Challenge = Instantiate(LavaJump, transform.position, transform.rotation) as GameObject;
        //Vector3 NextSpawner = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        //GameObject NextSpawn = Instantiate(Spawner, NextSpawner, transform.rotation) as GameObject;

        //DESTROY ITSELF

    }



}
