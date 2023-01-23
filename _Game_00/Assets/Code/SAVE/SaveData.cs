using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public int MAX_SCORE;
    public int MAX_DISTANCE;
    public int MAX_KILLS;
    public int TIME_LEFT; // FOR NOW THIS WILL DO SINCE IT'S ONLY GUI RELATED
    public int MAX_BULLET_COUNT;

public void set(int startingTime)
{
    MAX_SCORE = MAX_DISTANCE = MAX_KILLS = MAX_BULLET_COUNT = 0;
    TIME_LEFT = startingTime;
}

}