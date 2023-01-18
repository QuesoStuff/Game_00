using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript_Random : ItemScript, I_RANDOM
{


    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ITEM;
        base.set();
        randomGenerator();
    }
    public void Start()
    {
        set();
    }
    public void randomGenerator()
    {
        this.scoreAdded = Random.Range(CONSTANTS.ITEM_MINIMUM_SCORE, CONSTANTS.ITEM_MAXIMUM_SCORE);
        this.HP_Added = Random.Range(CONSTANTS.ITEM_MINIMUM_HP, CONSTANTS.ITEM_MAXIMUM_HP);
        spriterender.color = new Color(0, 0, 0, 1);
        if (HP_Added > scoreAdded)
            spriterender.color += Color.green;
        else if (scoreAdded > HP_Added)
            spriterender.color += Color.blue;
        else
            spriterender.color += new Color(1, (float)HP_Added / (float)CONSTANTS.ITEM_MAXIMUM_HP, (float)scoreAdded / (float)CONSTANTS.ITEM_MAXIMUM_SCORE);
    }

}
