using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BeaconSpawner : MonoBehaviour
{
    public static BeaconSpawner instance;
    private void Awake()
    {
        instance = this;
    }

    public Vector2 worldMin;
    public Vector2 worldMax;

    public GameObject beaconPrefab;
    private int walls;

    void Start()
    {
        SpawnBeacon();
    }
    
    public void SpawnBeacon()
    {
        walls = 0;
        Vector3 beaconPosition = new Vector3
            (Random.Range(worldMin.x, worldMax.x), 1, Random.Range(worldMin.y, worldMax.y));

        Collider[] objects = Physics.OverlapSphere(beaconPosition, 2f);
        foreach (Collider item in objects)
        {
            if (item.GetComponent<WallIdentifier>())
                walls++;
        }
        
        if(walls == 0)
            Instantiate(beaconPrefab, beaconPosition, Quaternion.identity);
        else
            SpawnBeacon();
    }
}
