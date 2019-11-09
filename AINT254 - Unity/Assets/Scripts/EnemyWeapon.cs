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



    public void Fire()
    {
        for (int i = 0; i < BulletSpawn.Length; i++)
        {
            Instantiate(Ammo, BulletSpawn[i].position, BulletSpawn[i].rotation);
        }
    }

    // Update is called once per frame
    void Start()
    {
        RandomShooting();
    }

    public void RandomShooting()
    {
        if (Dead == false)
        {
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