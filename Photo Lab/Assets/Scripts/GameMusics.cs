using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusics : MonoBehaviour
{
    public AudioClip[] music;

    private void Awake()
    {
        int musicID = Random.Range(0, music.Length);
        PlayMusic(musicID);
    }

    private void PlayMusic(int musicID) 
    {
        this.GetComponent<AudioSource>().clip = music[musicID];
        this.GetComponent<AudioSource>().Play();
    }
    
}
