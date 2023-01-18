using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] internal EnemyScript mainScript;
    [SerializeField] internal Enemy_Input INPUT;

    [SerializeField] internal float x;
    [SerializeField] internal float y;
    [SerializeField] internal Transform playerTransform;
    [SerializeField] internal float speed;
    [SerializeField] internal float RESET_SPEED;

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
        INPUT = GetComponent<Enemy_Input>();
        playerTransform = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<Transform>();
    }

    public void setRef()
    {
        //playerTransform = Resources.Load("Player").GetComponent<Transform>(); 
        //  mainScript = (EnemyScript)Resources.Load("enemy").GetComponent<EnemyScript>(); 
    }
    public void set()
    {
       setComponent();
        x = y = 0;
        speed = CONSTANTS.ENEMY_DEFAULT_SPEED;
        RESET_SPEED = speed;
    }
    public void resetSpeed()
    {
        speed = RESET_SPEED;
    }
    public void Enemy_Move_Fixed()
    {
        mainScript.rb2d.velocity = new Vector2(x, y) * speed;
    }
    public void moveCopy()
    {
        if (INPUT.input_move_up())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
            y = 0;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
            y = 0;
        }
        else
            x = y = 0;
    }
    public void moveCopy_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
            y = 0;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
            y = 0;
        }
        else
            x = y = 0;
    }
    public void moveCopyContinue()
    {
        if (INPUT.input_move_up())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
            y = 0;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
            y = 0;
        }
    }
    public void moveCopyContinue_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
            y = 0;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
            y = 0;
        }
    }
    public void moveCopyDiagonal()
    {
        if (INPUT.input_move_up())
        {
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
        }
        else x = y = 0;
    }
    public void moveCopyDiagonal_2()
    {
        if (INPUT.input_move_up_2())
        {
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
        }
        else x = y = 0;
    }
    public void moveCopyDiagonalContinue()
    {
        if (INPUT.input_move_up())
        {
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveCopyDiagonalContinue_2()
    {
        if (INPUT.input_move_up_2())
        {
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveCopyReverse()
    {
        if (INPUT.input_move_up())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = 0;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = 0;
        }
        else
            x = y = 0;

    }
    public void moveCopyReverse_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = 0;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = 0;
        }
        else
            x = y = 0;
    }
    public void moveCopyReverseContinuous()
    {
        if (INPUT.input_move_up())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = 0;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = 0;
        }
    }
    public void moveCopyReverseContinuous_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = 0;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 0;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = 0;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = 0;
        }
    }
    public void moveCopyDiagonalReverse()
    {
        if (INPUT.input_move_up())
        {
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagonalReverse_2()
    {
        if (INPUT.input_move_up_2())
        {
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagonalReverseContinue()
    {
        if (INPUT.input_move_up())
        {
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
        }
    }
    public void moveCopyDiagonalReverseContinue_2()
    {
        if (INPUT.input_move_up_2())
        {
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
        }
    }
    public void moveCopyDiagnalWeird()
    {
        if (INPUT.input_move_up())
        {
            x = -x;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = -x;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = -y;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = -y;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagnalWeird_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = -x;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = -x;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = -y;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = -y;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagnalWeird2()
    {
        var tempX = x;
        var tempY = y;
        if (INPUT.input_move_up())
        {
            x = -x;
            y = x;
        }
        else if (INPUT.input_move_down())
        {
            x = -x;
            y = x;
        }
        else if (INPUT.input_move_left())
        {
            x = y;
            y = -y;
        }
        else if (INPUT.input_move_right())
        {
            x = -y;
            y = -y;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagnalWeird2_2()
    {
        var tempX = x;
        var tempY = y;
        if (INPUT.input_move_up_2())
        {
            x = -x;
            y = x;
        }
        else if (INPUT.input_move_down_2())
        {
            x = -x;
            y = x;
        }
        else if (INPUT.input_move_left_2())
        {
            x = y;
            y = -y;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -y;
            y = -y;
        }
        else
            x = y = 0;
    }
    public void moveCopyDiagnalWeirdContinous()
    {
        if (INPUT.input_move_up())
        {
            x = -x;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = -x;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = -y;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = -y;
        }
    }
    public void moveCopyDiagnalWeirdContinous_2()
    {
        if (INPUT.input_move_up_2())
        {
            x = -x;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = -x;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = -y;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = -y;
        }
    }

    // USING BOTH DOWN & UP Keys
    public void moveFullKey_0()
    {
        if (INPUT.input_move_up())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_up_2())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = -1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveFullKey_1()
    {
        if (INPUT.input_move_up())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_up_2())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = 1;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = -1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
            y = 1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveFullKey_2()
    {
        if (INPUT.input_move_up())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_up_2())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_down())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_left())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_right())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = 1;
            y = -1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveFullKey_3()
    {
        if (INPUT.input_move_up())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_up_2())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_down())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_down_2())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_left())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_left_2())
        {
            x = -1;
            y = 1;
        }
        else if (INPUT.input_move_right())
        {
            x = 1;
            y = -1;
        }
        else if (INPUT.input_move_right_2())
        {
            x = -1;
            y = 1;
        }
        else
        {
            x = 0;
            y = 0;
        }
    }
    public void moveFollow()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            x = y = 0;
        }
    }
    public void moveFollow_Scatter()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            x = -x;
            y = -y;
        }
    }
    public void moveFollow_Scatter_x()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            x = -x;
        }
    }
    public void moveFollow_Scatter_y()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            y = -y;
        }
    }
    public void moveFollow_Scatter_inverse()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }
    public void moveFollow_Scatter_inverse_negative()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            var temp = x;
            x = -y;
            y = -temp;
        }
    }
    public void moveFollow_Scatter_inverse_negative_1()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            var temp = x;
            x = -y;
            y = temp;
        }
    }
    public void moveFollow_Scatter_inverse_negative_2()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else
        {
            var temp = x;
            x = y;
            y = -temp;
        }
    }
    public void moveFollowKeepGoing()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = newDirection.x;
        y = newDirection.y;
    }
    public void moveFollow_with_Stop_0()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        if (INPUT.input_move_up() || INPUT.input_move_down() || INPUT.input_move_left() || INPUT.input_move_right())
        {
            x = y = 0;
        }
    }
    public void moveFollow_with_Stop_1()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (newDirection.magnitude > CONSTANTS.ENEMY_TO_PLAYER_PROXY)
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        if (INPUT.input_move_up_2() || INPUT.input_move_down_2() || INPUT.input_move_left_2() || INPUT.input_move_right_2())
        {
            x = y = 0;
        }
    }
    public void moveFollow_Scared_0()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = -newDirection.x;
        y = -newDirection.y;
    }
    public void moveFollow_Scared_1()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = newDirection.y;
        y = newDirection.x;
    }
    public void moveFollow_Scared_2()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = newDirection.x;
        y = -newDirection.y;
    }
    public void moveFollow_Scared_3()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = -newDirection.x;
        y = newDirection.y;
    }
    public void moveFollow_Scared_4()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = -newDirection.y;
        y = -newDirection.x;
    }
    public void moveFollow_Scared_5()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = -newDirection.y;
        y = newDirection.x;
    }
    public void moveFollow_Scared_6()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        x = newDirection.y;
        y = -newDirection.x;
    }
    public void moveFollow_Scared_input_0()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (INPUT.input_trigger_pulled())
        {
            x = -newDirection.x;
            y = -newDirection.y;
        }
        else
        {
            x = newDirection.x;
            y = newDirection.y;
        }
    }
    public void moveFollow_Scared_input_1()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (INPUT.input_move_up() || INPUT.input_move_down() || INPUT.input_move_left() || INPUT.input_move_right())
        {
            x = newDirection.x;
            y = newDirection.y;
        }
        else if (INPUT.input_move_up_2() || INPUT.input_move_down_2() || INPUT.input_move_left_2() || INPUT.input_move_right_2())
        {
            x = -newDirection.x;
            y = -newDirection.y;
        }
    }
    public void moveFollow_Scared_input_2()
    {
        Vector2 newDirection = playerTransform.position - transform.position;
        if (INPUT.input_move_up() || INPUT.input_move_down() || INPUT.input_move_left() || INPUT.input_move_right())
        {
            x = -newDirection.x;
            y = -newDirection.y;
        }
        else if (INPUT.input_move_up_2() || INPUT.input_move_down_2() || INPUT.input_move_left_2() || INPUT.input_move_right_2())
        {
            x = newDirection.x;
            y = newDirection.y;
        }
    }
}