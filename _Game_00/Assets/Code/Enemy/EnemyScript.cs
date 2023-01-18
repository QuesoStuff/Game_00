using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MAIN_GAME_OBJECT_SCRIPT
{
    [SerializeField] internal Enemy_Controller Controller;
    [SerializeField] internal Enemy_Health Health;
    [SerializeField] internal Enemy_Color Color;
    [SerializeField] internal Enemy_Moves Moves;
    [SerializeField] internal Enemy_Collision Collision;
    [SerializeField] internal Enemy_Input INPUT;
    [SerializeField] internal EXPLOSION ex;
    //[SerializeField] internal RespawnScript respawnScript;
    [SerializeField] internal Random_Level_Gen respawnScript;

    [SerializeField] internal delegate void funct_ptr();
    [SerializeField] internal funct_ptr moveFunct_ptr;
    [SerializeField] internal int movementConfiguration;

    // Start is called before the first frame update
    /*
    void setRef()
    {
        explosionRef = Resources.Load("Explosion");
    }
    void setComponent()
    {
        player = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
    }
    */
    public void setComponent()
    {
        //GameObject temp = (GameObject)Resources.Load("enemy");
        Controller = GetComponent<Enemy_Controller>();
        Health = GetComponent<Enemy_Health>();
        Color = GetComponent<Enemy_Color>();
        Moves = GetComponent<Enemy_Moves>();
        Collision = GetComponent<Enemy_Collision>();
        INPUT = GetComponent<Enemy_Input>();
        ex = GetComponent<EXPLOSION>();
        //respawnScript = GameObject.Find(CONSTANTS.COLLISION_TAG_REPEAT).GetComponent<RespawnScript>();
        respawnScript = GameObject.Find("GameManager").GetComponent<Random_Level_Gen>();

    }

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ENEMY;
        base.set();
        setComponent();
        Controller.set();
        Health.set();
        Color.set();
        Moves.set();
        Collision.set();
        INPUT.set();
        movementConfiguration = Random.Range(1, CONSTANTS.ENEMY_MOVE_COUNT) % 4;
        //speed = Random.Range(1, CONSTANTS.MOVE_MAX_ENEMY_SPEED);
        //RESET_SPEED = speed;

        //enemyHP = Random.Range(1, CONSTANTS.ENEMY_HP_MAX);

        //movementConfiguration = Random.Range(1, CONSTANTS.ENEMY_MOVE_COUNT);

        //damageToPlayer = Random.Range(1, CONSTANTS.ENEMY_DAMAGE_MAX);

        //playerTransform = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).transform;
        //originalColor = spriterender.color;
    }






    void Start()
    {
        set();
        Moves.chooseMovement(movementConfiguration);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFunct_ptr != null)
            moveFunct_ptr();
    }
    void FixedUpdate()
    {
        Controller.Enemy_Move_Fixed();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_BULLET))
        {
            Collision.collisionWith_Bullet(other);
        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_TELEPORT))
        {
            Collision.collisionWith_Door(other);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_WALL)
        {
            Collision.collisionWith_Wall(collision);
        }

        if (collision.gameObject.tag == CONSTANTS.COLLISION_TAG_PLAYER)
        {
            Collision.collisionWith_Player(collision);
        }

    }





}
