using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_Traveled_Display : MonoBehaviour
{
    [SerializeField] internal _Player_Script playerScript; // in secs
    [SerializeField] internal Text textBox;
    [SerializeField] internal float distance;
    [SerializeField] internal int RATE;


    // Use this for initialization
    void setComponent()
    {
        playerScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
    }
    void set()
    {
        distance = (float)playerScript.total_Distance_traveled;
        RATE = 450;
    }
    void display()
    {
        distance = (float)playerScript.total_Distance_traveled / RATE;
        textBox.text = distance.ToString("F2") + "m";
    }
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        display();
    }
}