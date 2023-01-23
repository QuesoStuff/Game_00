using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] internal static float CurrentTime; // in secs
    [SerializeField] internal static int START_TIME = CONSTANTS.TIME_IN_LEVEL;



    // Use this for initialization
    public void set()
    {
        CurrentTime = START_TIME;
    }
    public void Start()
    {
        set();
    }
    public void Update()
    {
        updateTIme();
    }
    // Update is called once per frame
    public void updateTIme()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
            // may not be possible
            StartCoroutine(Level_Controller_Simple.timer_end_Restart());
    }
}