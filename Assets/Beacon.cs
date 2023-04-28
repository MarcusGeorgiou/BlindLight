using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            Destroy(gameObject);
            BeaconSpawner.instance.SpawnBeacon();
        }
    }
}
