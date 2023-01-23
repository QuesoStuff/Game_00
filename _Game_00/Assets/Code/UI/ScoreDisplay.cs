using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : GENERIC_UI
{
    [SerializeField] internal Color Color_Score_10;
    [SerializeField] internal int score;





    // Use this for initialization
    new void set()
    {
        base.set();
        score = ScoreManager.score;
        textBox.text = "Score: " + score.ToString();
        Color_Score_10 = new Color(1.0f, 0.64f, 0.0f, 1);
        newDisplayColor = new Color(0.2673554f, 0.1589534f, 7169812, 1);
    }
    void Start()
    {
        set();
    }
    void display()
    {
        score = ScoreManager.score;
        textColor();
        textBox.text = "Score: " + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        display();
        if (newSaveData == false)
            UI_UPDATE_High_Score();
    }

    void textColor()
    {
        if (score % 10 == 0 && score > 0)
        setTextColor(Color_Score_10);
        else
            setTextColor(displayColor);
    }
    void UI_UPDATE_High_Score()
    {
        if (score > saveFile.MAX_SCORE && saveFile.MAX_SCORE > 0)
        displayColor = newDisplayColor;
    }
}