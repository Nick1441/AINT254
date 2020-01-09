using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Player;
    public float Distance;
    public float Range = 400;

    public GameObject Floor;
    public GameObject Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    //Issue With Not Finding Players Tag On Start.
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        Distance = Vector3.Distance(Player.transform.position, transform.position);
        
        if (Distance <= Range)
        {
            GameObject FloorSpawn = Instantiate(Floor, transform.position, transform.rotation) as GameObject;

            Vector3 NextSpawner = new Vector3(transform.position.x, transform.position.y, transform.position.z + 50);
            GameObject NextSpawn = Instantiate(Spawner, NextSpawner, transform.rotation) as GameObject;

            Destroy(this.gameObject);
        }
    }
}
