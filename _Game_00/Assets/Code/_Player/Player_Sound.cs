
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound : MonoBehaviour
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal AudioClip[] soundtrack;
    [SerializeField] internal AudioSource playAudio; // graphical part, flips sprite if need be

    public void setComponent()
    {
        this.mainScript = GetComponent<_Player_Script>();
        this.playAudio = GetComponent<AudioSource>();

    }
    public void set()
    {
        setComponent();
    }
    public void audioShoot_0()
    {
        playAudio.clip = soundtrack[0];
        playAudio.Play();
    }
    public void audioShoot_1()
    {
        playAudio.clip = soundtrack[1];
        playAudio.Play();
    }
    public void audioShoot_charged()
    {
        playAudio.clip = soundtrack[2];
        playAudio.Play();
    }
    public void audioTeleport()
    {
        playAudio.clip = soundtrack[3];
        playAudio.Play();
    }
    public void audioCollision()
    {
        playAudio.clip = soundtrack[4];
        playAudio.Play();
    }
    public void audioDash()
    {
        playAudio.clip = soundtrack[5];
        playAudio.Play();
    }
    public void audioHurt()
    {
        playAudio.clip = soundtrack[6];
        playAudio.Play();
    }
}