using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MAIN_GAME_OBJECT_SCRIPT
{
    [SerializeField] internal Color originalColor;

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_WALL;
        base.set();
        originalColor = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
    }
    public void resetColor()
    {
        spriterender.color = originalColor;
    }
    public void Start()
    {
        set();
        resetColor();
    }

    // THIS IS LAZY I SHOULD NOT BE DOING THIS
        void Update()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_WALL;
    }

}