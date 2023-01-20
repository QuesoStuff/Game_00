
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUT : MonoBehaviour, I_INPUT //, I_other_Interface
{

    // ADDED SCRIPTS (internal allows to be accessed)

    // FIELDS (Unity types)

    // FIELDS (variables)
    [SerializeField] internal float timer_input_press_up;
    [SerializeField] internal float timer_input_press_down;
    [SerializeField] internal float timer_input_press_left;
    [SerializeField] internal float timer_input_press_right;
    [SerializeField] internal float timer_input_press_shoot;
    [SerializeField] internal bool dash_up;
    [SerializeField] internal bool dash_down;
    [SerializeField] internal bool dash_left;
    [SerializeField] internal bool dash_right;

    [SerializeField] internal int doubleTap;


    // SET and CONSTRUCTORS 
    public void set()
    {
        timer_input_press_up = 0;
        timer_input_press_down = 0;
        timer_input_press_left = 0;
        timer_input_press_right = 0;
        timer_input_press_shoot = 0;
        dash_up = dash_down = dash_left = dash_right = false;
        doubleTap = 0;
    }


    // GETTERS AND SETTERS


    // I_Parent_Interface METHOD DECLARATION (most likely Abstract)
    //I_Input_Directional,
    // NO BUTTON PRESS
    public bool input_iddle()
    {
        return (!Input.anyKeyDown);
    }
    // DIRECTION MOVEMENT 

    public bool input_move_up()
    {
        return (Input.GetKey(KeyCode.UpArrow));
    }
    public bool input_move_down()
    {
        return (Input.GetKey(KeyCode.DownArrow));
    }
    public bool input_move_left()
    {
        return (Input.GetKey(KeyCode.LeftArrow));
    }
    public bool input_move_right()
    {
        return (Input.GetKey(KeyCode.RightArrow));
    }


    public bool input_shoot_up()
    {
        return (Input.GetKey(KeyCode.UpArrow));
    }
    public bool input_shoot_down()
    {
        return (Input.GetKey(KeyCode.DownArrow));
    }
    public bool input_shoot_left()
    {
        return (Input.GetKey(KeyCode.LeftArrow));
    }
    public bool input_shoot_right()
    {
        return (Input.GetKey(KeyCode.RightArrow));
    }
    public bool input_shoot_up_release()
    {
        return (Input.GetKeyUp(KeyCode.UpArrow));
    }
    public bool input_shoot_down_release()
    {
        return (Input.GetKeyUp(KeyCode.DownArrow));
    }
    public bool input_shoot_left_release()
    {
        return (Input.GetKeyUp(KeyCode.LeftArrow));
    }
    public bool input_shoot_right_release()
    {
        return (Input.GetKeyUp(KeyCode.RightArrow));
    }
    public bool input_shoot()
    {
        return (Input.GetKeyDown(KeyCode.Space));
    }
    public virtual bool input_charged_Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            timer_input_press_shoot = Time.time;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var startPress = timer_input_press_shoot;
            if (Time.time - startPress >= CONSTANTS.CHARGED_SHOT_TIME)
            {
                return true;
            }
        }
        return false;
    }

    /* ORIGINAL DASH IMPLEMENTATION
        public bool input_dash(string input, ref float timer, float time_frame)
        {
            if (Input.GetKeyDown(input) && doubleTap < 1)
            {
                doubleTap = (doubleTap + 1) % 2;
                timer = Time.time;
                Debug.Log("first DASH: " + timer);
            }
            else if (Input.GetKeyDown(input) && doubleTap > 0)
            {
                Debug.Log("second DASH");
                doubleTap = (doubleTap + 1) % 2;
                Debug.Log(Time.time);
                Debug.Log(timer);
                Debug.Log(Time.time - timer);
                Debug.Log(time_frame);
                if (Time.time - timer <= time_frame)
                    return true;
                else
                    return false;
            }
            return false;
        }
        */
    public bool input_dash(string input, ref float timer, float time_frame)
    {
        if (Input.GetKeyDown(input))
        {
            var inputTime = timer;
            timer = Time.time;
            if (Time.time - inputTime <= time_frame)
            {

                return true;
            }
        }
        return false;
    }





    public bool input_dash_normal()
    {
        return (input_dash("up", ref timer_input_press_up, CONSTANTS.DASH_TIME) ||
                input_dash("down", ref timer_input_press_down, CONSTANTS.DASH_TIME) ||
                input_dash("left", ref timer_input_press_left, CONSTANTS.DASH_TIME) ||
                input_dash("right", ref timer_input_press_right, CONSTANTS.DASH_TIME));
    }


    public bool input_dash_quick()
    {
        return (input_dash("up", ref timer_input_press_up, CONSTANTS.DASH_TIME_QUICK) ||
                input_dash("down", ref timer_input_press_down, CONSTANTS.DASH_TIME_QUICK) ||
                input_dash("left", ref timer_input_press_left, CONSTANTS.DASH_TIME_QUICK) ||
                input_dash("right", ref timer_input_press_right, CONSTANTS.DASH_TIME_QUICK));
    }




}