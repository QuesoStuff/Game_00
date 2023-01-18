using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] internal float timeStart; // in secs
    [SerializeField] internal int min;
    [SerializeField] internal int sec;

    [SerializeField] internal Text textBox;
    [SerializeField] internal Level_Controller_Simple Repeat;
    [SerializeField] internal bool restart;


    // Use this for initialization
    void set()
    {
        timeStart = CONSTANTS.TIME_IN_LEVEL;
        convertTime();
        textBox.text = min.ToString() + " : " + sec.ToString();
        textBox.color = Color.white;
        gameObject.tag = CONSTANTS.COLLISION_TAG_CLOCK;
        restart = true;
    }
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            convertTime();
            textColor();
            if (sec > 10)
                textBox.text = min.ToString() + " : " + sec.ToString();
            else
                textBox.text = min.ToString() + " : 0" + sec.ToString();
        }
        else if (restart == true)
        {
            StartCoroutine(Repeat.Restart());
            restart = false;
        }
    }


    void convertTime()
    {
        min = (int)timeStart / 60;
        sec = (int)timeStart % 60;
    }
    void textColor()
    {
        if (timeStart < 60)
        {
            textBox.color = Color.red;
        }
        else if (timeStart < CONSTANTS.TIME_IN_LEVEL / 4)
        {
            textBox.color = new Color(1.0f, 0.64f, 0.0f , 1);
        }
        else if (timeStart < CONSTANTS.TIME_IN_LEVEL / 2)
        {
            textBox.color = Color.yellow;
        }
    }
}