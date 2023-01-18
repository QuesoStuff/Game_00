using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript_Random : EnemyScript , I_RANDOM
{


    public new void set()
    {
        base.set();
        randomGenerator();
    }

    
    public void random_move()
    {
        movementConfiguration = Random.Range(0, CONSTANTS.ENEMY_MOVE_COUNT);
        Moves.chooseMovement(movementConfiguration);
    }
    public void random_health()
    {
        Health.HP = Random.Range(1, CONSTANTS.ENEMY_HP_MAX);
    }
    public void random_damage()
    {
        Health.damageToPlayer = Random.Range(1, CONSTANTS.ENEMY_DAMAGE_MAX);
    }
    public void random_speed()
    {
        Controller.speed = Random.Range(1, CONSTANTS.MOVE_MAX_ENEMY_SPEED);
    }

    public void randomGenerator()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ENEMY;
        random_move();
        random_health();
        random_damage();
        random_speed();
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
            if (movementConfiguration < CONSTANTS.ENEMY_MOVEMENT_FOLLOW_SCATTER)
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
