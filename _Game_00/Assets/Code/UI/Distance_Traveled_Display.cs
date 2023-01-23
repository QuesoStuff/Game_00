using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_Traveled_Display : GENERIC_UI
{
    [SerializeField] internal float distance;
    [SerializeField] internal int RATE;


    // Use this for initialization

    new void set()
    {
        base.set();
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
        if (newSaveData == false)
            UI_UPDATE_High_Score();

    }
    void UI_UPDATE_High_Score()
    {
        if (playerScript.total_Distance_traveled > saveFile.MAX_DISTANCE && saveFile.MAX_DISTANCE > 0)
        {
            //newDisplayColor = color.green; DEFAULT IS YELLOW
            newSaveData = true;
            setTextColor(newDisplayColor);

        }
    }
}