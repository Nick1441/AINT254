using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject Ammo;
    public Transform[] BulletSpawn;
    public float FireCoolDown = 1.0f;
    private bool isFiring = false;



    public void Fire()
    {
        isFiring = true;
        for (int i = 0; i < BulletSpawn.Length; i++)
        {
            Instantiate(Ammo, BulletSpawn[i].position, BulletSpawn[i].rotation);
        }
        Invoke("SetFiring", FireCoolDown);
    }

    public void SetFiring()
    {
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
