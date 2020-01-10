using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject Ammo;
    public Transform[] BulletSpawn;
    private bool Dead = false;
    public float LowRange = 1f;
    public float HighRange = 5f;

    public GameObject Player;
    public float Distance;
    public float Range = 10;

    //Fires the wepon.
    //Currently Distance checker has been removed due to working in Unity, but not in builds.
    public void Fire()
    {
        Player = GameObject.FindWithTag("Player");
        Distance = Vector3.Distance(Player.transform.position, transform.position);

        //if (Distance <= Range)
        //{
            for (int i = 0; i < BulletSpawn.Length; i++)
            {
                Instantiate(Ammo, BulletSpawn[i].position, BulletSpawn[i].rotation);
            }
        //}
    }

    //Finds player. Calls shooing when loaded.
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        RandomShooting();
    }

    public void RandomShooting()
    {

        if (Dead == false)
        {
            Debug.Log("IN RANGE");
            float Rand = Random.Range(LowRange, HighRange);
            Invoke("FireMeth", Rand);
        }
    }

    public void FireMeth()
    {
        Fire();
        RandomShooting();
    }

}