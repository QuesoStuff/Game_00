using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MAIN_GAME_OBJECT_SCRIPT
{
    [SerializeField] internal Transform teleport;

    // regarding to animation of the Door
    [SerializeField] internal float opacityMeter;
    [SerializeField] internal float opacitySpeedFactor;

    [SerializeField] internal float opacityMeterShift;
    [SerializeField] internal bool increaseOpacity;
    [SerializeField] internal Color spriteColor;



    // Start is called before the first frame update
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_TELEPORT;
        base.set();
        // tag of the object
        // Unity Fields
        // other Fields
        opacityMeter = 0;
        opacityMeterShift = 0.001f;
        increaseOpacity = true;
    }
    void Start()
    {
        set();
    }
    // Update is called once per frame 
    void Update()
    {
        adjustOpacity();
    }



    void adjustOpacity()
    {
        if (opacityMeter >= 1)
            increaseOpacity = false;
        else if (opacityMeter <= 0)
            increaseOpacity = true;

        if (increaseOpacity == true)
            opacityMeter += opacityMeterShift;
        else
            opacityMeter -= opacityMeterShift;

        spriteColor = spriterender.color;
        spriteColor.a = opacityMeter;
        spriterender.color = spriteColor;
    }
}
