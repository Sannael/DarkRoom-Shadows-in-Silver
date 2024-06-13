using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds instance = null;
    public AudioSource sfxSource;

    [HideInInspector]
    public bool timeSc;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (timeSc == true)
        {
            if (Time.timeScale == 0)
            {
                sfxSource.Pause();
            }
            else if (sfxSource.isPlaying == false)
            {
                sfxSource.UnPause();
            }

        }
    }

    public GameObject CreateNewSoundLoop(AudioClip clip)
    {
        GameObject s = Instantiate(gameObject);
        s.GetComponent<Sounds>().sfxSource.loop = true;
        s.GetComponent<Sounds>().PlaySingle(clip);
        s.GetComponent<Sounds>().timeSc = true;
        return s;
    }

    public void CreateNewSound(AudioClip clip)
    {
        GameObject s = Instantiate(gameObject);
        s.GetComponent<Sounds>().PlaySingle(clip);
        s.GetComponent<Sounds>().timeSc = true;
        Destroy(s, clip.length);
    }

    public void CreateNewSoundNoScale(AudioClip clip)
    {
        GameObject s = Instantiate(gameObject);
        s.GetComponent<Sounds>().PlaySingle(clip);
        s.GetComponent<Sounds>().timeSc = false;
        Destroy(s, clip.length);
    }

    public void PlaySingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
