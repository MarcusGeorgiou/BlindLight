using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource melody;

    private float delay = 20f;
    private float timeCounter;

    private void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= delay && !melody.isPlaying)
        {
            melody.Play();
            timeCounter = 0f;
        }
    }
}
