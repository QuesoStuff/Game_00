using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript_Level : ItemScript, I_LEVEL
{
    [SerializeField] internal int interval;
    [SerializeField] internal Color startingColor;

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ITEM;
        spriterender = GetComponent<SpriteRenderer>();
        startingColor = spriterender.color;
        base.set();
        level_generator();
    }
    public void Start()
    {
        set();
    }
    // inverse relationship with score (the higher one the lower the other)
    public void level_score_select()
    {
        interval = CONSTANTS.ITEM_MAXIMUM_SCORE / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
        scoreAdded   = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.green)
        scoreAdded   = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        scoreAdded   = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.black)
        scoreAdded   = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.white)
        scoreAdded   = Random.Range(4 * interval , 5 * interval);
    }
    public void level_health_select()
    {
        interval = CONSTANTS.ITEM_MAXIMUM_SCORE / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.white)
        HP_Added   = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.black)
        HP_Added   = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        HP_Added   = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.green)
        HP_Added   = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.red)
        HP_Added   = Random.Range(4 * interval , 5 * interval);
    }
    public void level_generator()
    {
        level_score_select();
        level_health_select();
    }

}
