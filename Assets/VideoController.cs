using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public string url;
    private VideoPlayer player;


    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
        player.url = url;
    }

    void Start()
    {
        player.Play();
        player.isLooping = true;
    }
}
