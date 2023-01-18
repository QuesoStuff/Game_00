
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MAIN_GAME_OBJECT_SCRIPT
{
    // other scripts
    [SerializeField] internal Player_Input INPUT;
    [SerializeField] internal _Player_Script mainScript;
    // movement
    [SerializeField] internal int x;
    [SerializeField] internal int y;
    [SerializeField] internal int currSpeed_up;
    [SerializeField] internal int currSpeed_down;
    [SerializeField] internal int currSpeed_left;
    [SerializeField] internal int currSpeed_right;
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




    public void straight_shot()
    {
        if (INPUT.input_move_up())
        {
            bullet_x = 0;
            bullet_y = 1;
        }
        else if (INPUT.input_move_down())
        {
            bullet_x = 0;
            bullet_y = -1;
        }
        if (INPUT.input_move_left())
        {
            bullet_x = -1;
            bullet_y = 0;
        }
        else if (INPUT.input_move_right())
        {
            bullet_x = 1;
            bullet_y = 0;
        }
    }
    public void diagnol_shot()
    {
        if (INPUT.input_move_up() && INPUT.input_move_left())
        {
            bullet_x = -1;
            bullet_y = 1;
        }
        else if (INPUT.input_move_up() && INPUT.input_move_right())
        {
            bullet_x = 1;
            bullet_y = 1;
        }
        if (INPUT.input_move_down() && INPUT.input_move_left())
        {
            bullet_x = -1;
            bullet_y = -1;
        }
        else if (INPUT.input_move_down() && INPUT.input_move_right())
        {
            bullet_x = 1;
            bullet_y = -1;
        }
    }
    public void ultimate_shot()
    {
        straight_shot();
        diagnol_shot();
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
    public void player_Moving_Diagnol() // input inside update , move inside of fixed
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
        rb2d.velocity = new Vector2(x, y);
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
        //tr.emitting = true;
        yield return new WaitForSeconds(time);
        //tr.emitting = false;
        isDashing = false;
        currSpeed_down = currSpeed_up = currSpeed_left = currSpeed_right = CONSTANTS.MOVE_DEFAULT_SPEED;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        //mainScript.Color.resetColor();
    }

}