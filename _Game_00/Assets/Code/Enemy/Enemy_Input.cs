
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Input : INPUT
{

    // ADDED SCRIPTS (internal allows to be accessed)
    // FIELDS (Unity types)
    // FIELDS (variables)
    // SET and CONSTRUCTORS 
    [SerializeField] internal EnemyScript mainScript;

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
    }
    public new void set()
    {
        base.set();
        setComponent();
    }
    public bool input_trigger_pulled()
    {
        return (Input.GetKey(KeyCode.Space));
    }
    public bool input_move_up_2()
    {
        return (Input.GetKeyUp(KeyCode.UpArrow));
    }
    public bool input_move_down_2()
    {
        return (Input.GetKeyUp(KeyCode.DownArrow));
    }
    public bool input_move_left_2()
    {
        return (Input.GetKeyUp(KeyCode.LeftArrow));
    }
    public bool input_move_right_2()
    {
        return (Input.GetKeyUp(KeyCode.RightArrow));
    }
    public bool input_shoot_start()
    {
        return (Input.GetKeyDown(KeyCode.Space));
    }
    public bool input_shoot_done()
    {
        return (Input.GetKeyUp(KeyCode.Space));
    }
    // I_other_Interface METHOD DECLARATION (may not exist)
}