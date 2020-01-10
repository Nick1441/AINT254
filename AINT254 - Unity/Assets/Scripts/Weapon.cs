using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject Ammo;
    public Transform[] BulletSpawn;
    public float FireCoolDown = 1.0f;
    private bool isFiring = false;
    AudioSource AudioS;

    void Start()
    {
        
    }

    //Creates Ammo Prefab from spawn point. Adds Cooldown so cannot be called unitl time runs down.
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

    //Checking to see if the user has fired the weapon.
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
                AudioSource AudioS = gameObject.GetComponent<AudioSource>();
                AudioS.Play();
            }
        }
    }
}
