
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MAIN_GAME_OBJECT_SCRIPT
{
    // other scripts
    [SerializeField] internal Player_Input INPUT;
    [SerializeField] internal _Player_Script mainScript;
    // movement
    [SerializeField] internal float x;
    [SerializeField] internal float y;
    [SerializeField] internal int currSpeed_up;
    [SerializeField] internal int currSpeed_down;
    [SerializeField] internal int currSpeed_left;
    [SerializeField] internal int currSpeed_right;

    [SerializeField] internal float currSpeed_up_diagonal;
    [SerializeField] internal float currSpeed_down_diagonal;
    [SerializeField] internal float currSpeed_left_diagonal;
    [SerializeField] internal float currSpeed_right_diagonal;
    // dashing movement
    [SerializeField] internal bool canDash;
    [SerializeField] internal bool isDashing;
    [SerializeField] internal int dashSpeed;
    [SerializeField] internal int dashSpeed_quick;

    [SerializeField] internal float dashingTime;
    [SerializeField] internal float quickDashTime;

    [SerializeField] internal float dashingCooldown;
    [SerializeField] internal int pushBack;
    // MOVEMENT TRACKER
    [SerializeField] internal Vector2 previousLoc;
    // shooting
    [SerializeField] internal Object bullet_ref;
    [SerializeField] internal Object chargedBullet_ref;
    [SerializeField] internal int bullet_x;
    [SerializeField] internal int bullet_y;
    [SerializeField] internal Vector2 bulletPosition;
    // other related things

    [SerializeField] internal Object explosion_ref;
    [SerializeField] internal BulletScript bullet_config;

    public void setRef()
    {
        bullet_ref = Resources.Load("bullet");
        chargedBullet_ref = Resources.Load("bigBullet");
        explosion_ref = Resources.Load("explosion_dash");
        //explosion_ref = Resources.Load("explosion_dash_but_better");

    }
    public void setComponent()
    {
        mainScript = GetComponent<_Player_Script>();
        INPUT = GetComponent<Player_Input>();
    }
    public new void set()
    {
        //base.set();
        setComponent();
        setRef();
        x = y = 0;
        currSpeed_down = currSpeed_up = currSpeed_left = currSpeed_right = CONSTANTS.MOVE_DEFAULT_SPEED;
        currSpeed_down_diagonal = currSpeed_up_diagonal = currSpeed_left_diagonal = currSpeed_right_diagonal = CONSTANTS.MOVE_DEFAULT_SPEED / Mathf.Sqrt(2.0f);

        canDash = true;
        isDashing = false;
        dashSpeed = 10;
        dashSpeed_quick = 25;
        dashingTime = 1.3f;
        quickDashTime = 0.3f;
        dashingCooldown = 2f;
        pushBack = 5000;
    }
    public void RecordDistance()
    {
        mainScript.total_Distance_traveled += Vector2.Distance(transform.position, previousLoc);
        previousLoc = transform.position;
    }


    // for testing the 8-Directional shooting



    public void all_shot()
    {
        if (INPUT.input_shoot_up())
        {
            bullet_y = 1;
        }
        else if (INPUT.input_shoot_down())
        {
            bullet_y = -1;
        }
        if (INPUT.input_shoot_left())
        {
            bullet_x = -1;
        }
        else if (INPUT.input_shoot_right())
        {
            bullet_x = 1;
        }
        if (INPUT.input_shoot_up_release() || INPUT.input_shoot_down_release())
        {
            bullet_y = 0;
        }
        if (INPUT.input_shoot_left_release() || INPUT.input_shoot_right_release())
        {
            bullet_x = 0;
        }
    }

    public void straight_shot()
    {
        if (INPUT.input_shoot_up())
        {
            bullet_x = 0;
            bullet_y = 1;
            Debug.Log(" straight UP");
        }
        else if (INPUT.input_shoot_down())
        {
            bullet_x = 0;
            bullet_y = -1;
            Debug.Log(" straight DOWN");
        }
        if (INPUT.input_shoot_left())
        {
            bullet_x = -1;
            bullet_y = 0;
            Debug.Log(" straight LEFT");
        }
        else if (INPUT.input_shoot_right())
        {
            bullet_x = 1;
            bullet_y = 0;
            Debug.Log(" straight RIGHT");
        }
    }
    public void diagnol_shot()
    {
        if (INPUT.input_shoot_up() && INPUT.input_shoot_left())
        {
            bullet_x = -1;
            bullet_y = 1;
            Debug.Log(" DI - UP + LEFT ");
        }
         if (INPUT.input_shoot_up() && INPUT.input_shoot_right())
        {
            bullet_x = 1;
            bullet_y = 1;
            Debug.Log(" DI - UP + RIGHT ");
        }
         if (INPUT.input_shoot_down() && INPUT.input_shoot_left())
        {
            bullet_x = -1;
            bullet_y = -1;
            Debug.Log(" DI - DOWN + LEFT ");
        }
         if (INPUT.input_shoot_down() && INPUT.input_shoot_right())
        {
            bullet_x = 1;
            bullet_y = -1;
            Debug.Log(" DI - DOWN + RIGHT");
        }
    }
    public void ultimate_Player_Shooting()
    {
        // the most reliable approach thus far
       // straight_shot();
        diagnol_shot();

        // this sequence does some funky things
        //diagnol_shot();
        //straight_shot();

        // latest attempt (the bullet stops when you release buttons)
        //all_shot();
    }
    public void ultimate_direction_input()
    {
        x = y = 0;
        if (INPUT.input_move_up())
        {
            x = 0;
            y = currSpeed_up;
            bullet_x = 0;
            bullet_y = 1;
        }
        if (INPUT.input_move_down())
        {
            x = 0;
            y = -currSpeed_down;
            bullet_x = 0;
            bullet_y = -1;
        }
        if (INPUT.input_move_left())
        {
            x = -currSpeed_left;
            y = 0;
            bullet_x = -1;
            bullet_y = 0;
        }
        if (INPUT.input_move_right())
        {
            x = currSpeed_right;
            y = 0;
            bullet_x = 1;
            bullet_y = 0;
        }
        if (INPUT.input_move_up() && INPUT.input_move_left())
        {
            x = -currSpeed_left_diagonal;
            y = currSpeed_up_diagonal;
            bullet_x = -1;
            bullet_y = 1;
        }
        if (INPUT.input_move_up() && INPUT.input_move_right())
        {
            x = currSpeed_left_diagonal;
            y = currSpeed_up_diagonal;
            bullet_x = 1;
            bullet_y = 1;
        }
        if (INPUT.input_move_down() && INPUT.input_move_left())
        {
            x = -currSpeed_left_diagonal;
            y = -currSpeed_up_diagonal;
            bullet_x = -1;
            bullet_y = -1;
        }
        if (INPUT.input_move_down() && INPUT.input_move_right())
        {
            x = currSpeed_left_diagonal;
            y = -currSpeed_up_diagonal;
            bullet_x = 1;
            bullet_y = -1;
        }
    }
    public void ultimate_Player_Moving()
    {
        player_Moving();
        player_Moving_Diagnol();

    }
    public void player_Moving()
    {
        x = y = 0;
        if (INPUT.input_move_up())
        {
            x = 0;
            y = currSpeed_up;
        }
        else if (INPUT.input_move_down())
        {
            x = 0;
            y = -currSpeed_down;
        }
        else if (INPUT.input_move_left())
        {
            x = -currSpeed_left;
            y = 0;
        }
        else if (INPUT.input_move_right())
        {
            x = currSpeed_right;
            y = 0;
        }
    }
    // new diagnol Jan 19th
    public void player_Moving_Diagnol() // input inside update , move inside of fixed
    {
        //x = y = 0;
        if (INPUT.input_move_up() && INPUT.input_move_left())
        {
            x = -currSpeed_left_diagonal;
            y = currSpeed_up_diagonal;
        }
        else if (INPUT.input_move_up() && INPUT.input_move_right())
        {
            x = currSpeed_left_diagonal;
            y = currSpeed_up_diagonal;
        }
        else if (INPUT.input_move_down() && INPUT.input_move_left())
        {
            x = -currSpeed_left_diagonal;
            y = -currSpeed_up_diagonal;
        }
        else if (INPUT.input_move_down() && INPUT.input_move_right())
        {
            x = currSpeed_left_diagonal;
            y = -currSpeed_up_diagonal;
        }
    }
    public void player_Moving_Diagnol_() // input inside update , move inside of fixed
    {
        x = y = 0;
        if (INPUT.input_move_up())
        {
            y = currSpeed_up;
        }
        else if (INPUT.input_move_down())
        {
            y = -currSpeed_down;
        }
        if (INPUT.input_move_left())
        {
            x = -currSpeed_left;
        }
        else if (INPUT.input_move_right())
        {
            x = currSpeed_right;
        }
    }
    public void shooting()
    {
        if (INPUT.input_shoot())
        {
            mainScript.bullet_shot_Count++; // jan 19th
            Debug.Log("shooting");
            var x = bullet_x;
            var y = bullet_y;
            bulletPosition = transform.position;
            GameObject bulletObject = (GameObject)Instantiate(bullet_ref, bulletPosition, Quaternion.identity);
            //bullet_config = bulletObject.GetComponent<BulletScript>();
            bulletObject.GetComponent<BulletScript>().x = x;
            bulletObject.GetComponent<BulletScript>().y = y;
            mainScript.bullet_shot_Count++;
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                mainScript.SFX.audioShoot_0();
            else
                mainScript.SFX.audioShoot_1();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("TRIGGER RELEASE");
        }
    }
    public void charged_Shooting()
    {
        if (INPUT.input_charged_Shot())
        {
            mainScript.SFX.audioShoot_charged();
            var x = bullet_x;
            var y = bullet_y;
            bulletPosition = transform.position;
            GameObject bulletObject = (GameObject)Instantiate(chargedBullet_ref, bulletPosition, Quaternion.identity);
            bulletObject.GetComponent<BulletScript>().x = (float)x / (float)CONSTANTS.MOVE_DEFAULT_SPEED;
            bulletObject.GetComponent<BulletScript>().y = (float)y / (float)CONSTANTS.MOVE_DEFAULT_SPEED;
            mainScript.bullet_shot_Count++;
            bulletObject.GetComponent<BulletScript>().bullet_damge = 10;
            // for debug purposes
        }
    }


    public void playerDash()
    {
        //if (INPUT.input_dash_quick() && canDash)
        //{
        //    StartCoroutine(Dash(dashSpeed_quick, quickDashTime));
        //}
        if (INPUT.input_dash_normal() && canDash)
        {
            mainScript.SFX.audioDash();
            StartCoroutine(Dash(dashSpeed, dashingTime));
        }
    }
    public void player_Move_Fixed()
    {
        Vector2 direction = new Vector2(x, y);
        //direction = direction.normalized;
        rb2d.velocity = direction;
    }
    public IEnumerator Dash(int dashSpeed, float time)
    {
        canDash = false;
        //spriterender.color = Color.white;
        StartCoroutine(mainScript.Color.dash());
        isDashing = true;
        //mainScript.ex.explosionCreate(explosion_ref, transform.position, spriterender.color);
        mainScript.ex.explosionCreateConsant(explosion_ref, transform.position, spriterender.color);
        //rb2d.AddForce(dash * rb2d.velocity);
        currSpeed_down = currSpeed_up = currSpeed_left = currSpeed_right = dashSpeed;
        currSpeed_down_diagonal = currSpeed_up_diagonal = currSpeed_left_diagonal = currSpeed_right_diagonal = dashSpeed / Mathf.Sqrt(2.0f);

        //tr.emitting = true;
        yield return new WaitForSeconds(time);
        //tr.emitting = false;
        isDashing = false;
        currSpeed_down = currSpeed_up = currSpeed_left = currSpeed_right = CONSTANTS.MOVE_DEFAULT_SPEED;
        currSpeed_down_diagonal = currSpeed_up_diagonal = currSpeed_left_diagonal = currSpeed_right_diagonal = CONSTANTS.MOVE_DEFAULT_SPEED_DIAGONAL;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        //mainScript.Color.resetColor();
    }

}