using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Music : MonoBehaviour
{
    [SerializeField] internal AudioClip[] soundtrack;
    [SerializeField] internal CameraPlayerFollow camColor;
    [SerializeField] internal bool not_first_track;



    // Use this for initialization
    void set()
    {
        not_first_track = false;
        camColor = GameObject.Find("Main Camera").GetComponent<CameraPlayerFollow>();
    }
    void Start()
    {
        set();
        if (!GetComponent<AudioSource>().playOnAwake)
        {
            // -1 BECAUSE THE LAST TRACK IS A BONUS TRACK
            playMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            playMusic();
            if (not_first_track == true)
            {
                float r = Random.Range(0, 1.0f);
                float g = Random.Range(0, 1.0f);
                float b = Random.Range(0, 1.0f);
                camColor.transitionColor(new Color(r, g, b, 1));
            }
            not_first_track = true;
        }
    }

    public void playMusic()
    {
        GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length - 1)];
        GetComponent<AudioSource>().Play();
    }
    public void playPauseMusic()
    {
        GetComponent<AudioSource>().clip = soundtrack[soundtrack.Length-1];
        GetComponent<AudioSource>().Play();
    }
}

