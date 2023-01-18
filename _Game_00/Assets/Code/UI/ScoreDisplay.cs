using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] internal ScoreManager scoreScript; // in secs
    [SerializeField] internal Text textBox;
    [SerializeField] internal Color mileStone;
    [SerializeField] internal Color newScore;

    [SerializeField] internal int hi_score;



    // Use this for initialization
    void set()
    {
        textBox.text = "Score: " + scoreScript.score.ToString();
        textBox.color = Color.white;
        mileStone = new Color(1.0f, 0.64f, 0.0f , 1);
        newScore = new Color(0.2673554f, 0.1589534f, 7169812 , 1);

        hi_score = scoreScript.highScore;

    }
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        set();
    }

        void textColor()
    {
        if (scoreScript.score % 10 == 0)
        textBox.color = mileStone;
        if (scoreScript.score > hi_score)
        textBox.color = newScore;
        else
        textBox.color = Color.white;


    }
}