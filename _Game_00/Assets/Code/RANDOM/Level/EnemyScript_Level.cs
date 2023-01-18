using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript_Level : EnemyScript , I_LEVEL
{
    [SerializeField] internal Color startingColor;
    [SerializeField] internal int interval;


    [SerializeField] internal Color red = new Color(1,0,0,1);
    [SerializeField] internal Color green = new Color(0,1,0,1);
    [SerializeField] internal Color blue = new Color(0,0,1,1);
    [SerializeField] internal Color black = new Color(0,0,0,1);
    [SerializeField] internal Color white = new Color(1,1,1,1);




    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ENEMY;
        spriterender = GetComponent<SpriteRenderer>();
        startingColor = spriterender.color;
        base.set();
        level_generator();
    }

    
    public void level_move_select()
    {
        interval = CONSTANTS.ENEMY_MOVE_COUNT / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
        movementConfiguration = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.green)
        movementConfiguration = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        movementConfiguration = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.black)
        movementConfiguration = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.white)
        movementConfiguration = Random.Range(4 * interval , 5 * interval);

        Moves.chooseMovement(movementConfiguration);
    }
    public void level_health_select()
    {
        
        interval = CONSTANTS.ENEMY_HP_MAX / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
        Health.HP  = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.green)
        Health.HP  = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        Health.HP  = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.black)
        Health.HP  = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.white)
        Health.HP  = Random.Range(4 * interval , 5 * interval);
    }
    public void level_damage_select()
    {
        interval = CONSTANTS.ENEMY_DAMAGE_MAX / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
        Health.damageToPlayer  = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.green)
        Health.damageToPlayer  = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        Health.damageToPlayer  = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.black)
        Health.damageToPlayer  = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.white)
        Health.damageToPlayer  = Random.Range(4 * interval , 5 * interval);
    }
    public void level_speed_select()
    {
        interval = CONSTANTS.MOVE_MAX_ENEMY_SPEED / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
        Controller.speed   = Random.Range(0 * interval , 1 * interval);
        else if (startingColor == Color.green)
        Controller.speed   = Random.Range(1 * interval , 2 * interval);
        else if (startingColor == Color.blue)
        Controller.speed   = Random.Range(2 * interval , 3 * interval);
        else if (startingColor == Color.black)
        Controller.speed   = Random.Range(3 * interval , 4 * interval);
        else if (startingColor == Color.white)
        Controller.speed   = Random.Range(4 * interval , 5 * interval);
    }

    public void level_generator()
    {
        level_move_select();
        level_health_select();
        level_damage_select();
        level_speed_select();
        // color change to reflect this
        Color.set();
    }

    void Start()
    {
        set();
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
