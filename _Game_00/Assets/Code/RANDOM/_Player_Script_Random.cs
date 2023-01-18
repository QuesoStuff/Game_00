
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player_Script_Random : _Player_Script, I_RANDOM
{
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_PLAYER;
        base.set();
        randomGenerator();
    }

    public void randomGenerator()
    {
        Vector3 startLocation = Vector2.zero;
        var x = Random.Range(CONSTANTS.TESTROOM_X_AXIS_MIN, CONSTANTS.TESTROOM_X_AXIS_MAX);
        var y = Random.Range(CONSTANTS.TESTROOM_Y_AXIS_MIN, CONSTANTS.TESTROOM_Y_AXIS_MAX);
        startLocation.x = x;
        startLocation.y = y;
        transform.position = startLocation;
    }

    void Awake()
    {
        set();
    }
    public new void Start()
    {
    }
    public new void Update()
    {
        base.Update();
    }
    // Update is called once per frame (for physics and fixed frameRate)
    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }
}

