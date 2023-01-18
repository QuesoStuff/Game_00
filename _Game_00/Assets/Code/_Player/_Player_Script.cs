
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player_Script : MAIN_GAME_OBJECT_SCRIPT
{

    // ADDED SCRIPTS (internal allows to be accessed)
    [SerializeField] internal Player_Collision Collision; // engage with game world items
    [SerializeField] internal Player_Health HP;
    [SerializeField] internal ScoreManager Score;
    [SerializeField] internal Player_Color Color;
    [SerializeField] internal Player_Controller Controller;
    [SerializeField] internal Player_Input INPUT;
    [SerializeField] internal Player_Sound SFX;

    [SerializeField] internal EXPLOSION ex;

    [SerializeField] internal int killCount;
    [SerializeField] internal int bullet_shot_Count;
    [SerializeField] internal float total_Distance_traveled;




    void setComponent()
    {

        Collision = GetComponent<Player_Collision>();
        HP = GetComponent<Player_Health>();
        Score = GetComponent<ScoreManager>();
        Color = GetComponent<Player_Color>();
        Controller = GetComponent<Player_Controller>();
        INPUT = GetComponent<Player_Input>();
        ex = GetComponent<EXPLOSION>();
        SFX = GetComponent<Player_Sound>();
    }





    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_PLAYER;
        setComponent();
        base.set();
        Collision.set();
        HP.set();
        Score.set();
        Controller.set();
        Color.set();
        INPUT.set();
        SFX.set();
        killCount = 0;
        total_Distance_traveled = 0;
        bullet_shot_Count = 0;
    }

    // Gets called before Start()
    void Awake()
    {
        set();
    }
    // Start is called before the first frame update
    public void Start()
    {

    }
    void wrap_around() // for the INF room
    {
        if (transform.position.x > CONSTANTS.TESTROOM_X_AXIS_MAX)
            transform.position = new Vector2(CONSTANTS.TESTROOM_X_AXIS_MIN, transform.position.y);
        else if (transform.position.x < CONSTANTS.TESTROOM_X_AXIS_MIN)
            transform.position = new Vector2(CONSTANTS.TESTROOM_X_AXIS_MAX, transform.position.y);
        if (transform.position.y > CONSTANTS.TESTROOM_Y_AXIS_MAX)
            transform.position = new Vector2(transform.position.x, CONSTANTS.TESTROOM_Y_AXIS_MIN);
        else if (transform.position.y < CONSTANTS.TESTROOM_Y_AXIS_MIN)
            transform.position = new Vector2(transform.position.x, CONSTANTS.TESTROOM_Y_AXIS_MAX);

    }

    // Update is called once per frame
    public void Update()
    {
        Controller.playerDash();
        Controller.player_Moving();
        Controller.ultimate_shot();
        Controller.shooting();
        //INPUT.input_charged_Shot_Ready();
        Controller.charged_Shooting();
        Controller.RecordDistance();
        wrap_around();
    }
    // Update is called once per frame (for physics and fixed frameRate)
    public void FixedUpdate()
    {
        Controller.player_Move_Fixed();
    }


    // COLLISION
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Item interactions
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_ITEM))
        {
            Collision.collsionWith_Item(other);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_TELEPORT))
        {
            Collision.collisionWith_Door(other);
            SFX.audioTeleport();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_ENEMY)
        {
            Collision.collisionWith_Enemy(collision);
            SFX.audioCollision();
        }
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall(collision);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall_EXIT(collision);
        }
    }



}

