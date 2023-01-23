using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Display : GENERIC_UI
{

    [SerializeField] internal int currHP;
    [SerializeField] internal int maxHP;
    [SerializeField] internal Color HP_Color_Full;
    [SerializeField] internal Color HP_Color_Normal;
    [SerializeField] internal Color HP_Color_Half;
    [SerializeField] internal Color HP_Color_Danger;




    // Use this for initialization
    new void set()
    {
        base.set();
        currHP = playerScript.HP.HP;
        maxHP = playerScript.HP.HP_Max;
        setTextColor();
        ColorUtility.TryParseHtmlString("00FF00FF", out HP_Color_Full); // green 
        ColorUtility.TryParseHtmlString("FFFFFFFF", out HP_Color_Normal); // white
        ColorUtility.TryParseHtmlString("FFFF00FF", out HP_Color_Half); // yellow
        ColorUtility.TryParseHtmlString("FF0000FF", out HP_Color_Danger); // red

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

    void setTextColor()
    {
        if (currHP == maxHP) // white
            textBox.text = $" <color=#00FF00FF>{currHP}</color>/" + maxHP.ToString();
        else if ((float)currHP / (float)maxHP < 0.35f) // red 
            textBox.text = $" <color=#FF0000FF>{currHP}</color>/" + maxHP.ToString();
        else if ((float)currHP / (float)maxHP < 0.70) // yellow
            textBox.text = $" <color=#FFFF00FF>{currHP}</color>/" + maxHP.ToString();
        else //white
            textBox.text = $" <color=#FFFFFFFF>{currHP}</color>/" + maxHP.ToString();

    }
    void display()
    {
        currHP = playerScript.HP.HP;
        maxHP = playerScript.HP.HP_Max;
        setTextColor();
    }
}

