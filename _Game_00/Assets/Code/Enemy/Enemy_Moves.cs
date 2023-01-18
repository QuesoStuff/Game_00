using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Moves : MonoBehaviour
{
    [SerializeField] internal EnemyScript mainScript;
    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
    }
    public void set()
    {
        setComponent();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void chooseMovement(int movementConfiguration)
    {
        if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopy;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_CONTINUE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyContinue;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_DIAGONAL)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonal;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_DIAGONAL_CONTINUE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalContinue;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyReverse;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_CONTINUE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyReverseContinuous;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalReverse;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_CONTINUE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalReverseContinue;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeird;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD_CONTINUE)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeirdContinous;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter;


        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_X)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_x;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_Y)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_y;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_INV)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_inverse;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_0)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_inverse_negative;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_1)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_inverse_negative_1;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scatter_inverse_negative_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_KEEP)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollowKeepGoing;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeird2;

        // new ones


        if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopy_2;
        if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_DIAGONAL_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonal_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyReverse_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalReverse_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD_2_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeird2_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD_FOLLOW_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeirdContinous_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_CONTINUE_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyContinue_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_DIAGONAL_CONTINUE_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalContinue_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_CONTINUE_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyReverseContinuous_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_CONTINUE_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagonalReverseContinue_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_WEIRD_2_)
            mainScript.moveFunct_ptr = mainScript.Controller.moveCopyDiagnalWeird_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_STOP_0)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_with_Stop_0;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_STOP_1)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_with_Stop_1;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_0)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_0;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_1)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_1;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_3)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_3;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_4)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_4;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_5)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_5;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_6)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_6;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_0)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_input_0;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_1)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_input_1;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFollow_Scared_input_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVE_FULL_KEY_0)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFullKey_0;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVE_FULL_KEY_1)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFullKey_1;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVE_FULL_KEY_2)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFullKey_2;
        else if (movementConfiguration == CONSTANTS.ENEMY_MOVE_FULL_KEY_3)
            mainScript.moveFunct_ptr = mainScript.Controller.moveFullKey_3;
    }
}







