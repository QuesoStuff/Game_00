using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript_Random : WallScript, I_RANDOM
{

    [SerializeField] internal float xMove;
    [SerializeField] internal float yMove;
    [SerializeField] internal Vector2 travel;
    [SerializeField] internal float speed;
    [SerializeField] internal Color startingColor;

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ITEM;
        spriterender = GetComponent<SpriteRenderer>();
        startingColor = spriterender.color;
        base.set();
        gameObject.tag = CONSTANTS.COLLISION_TAG_WALL;
        xMove = Random.Range(-1, 2);
        yMove = Random.Range(-1, 2);
        speed = Random.Range(-CONSTANTS.MOVE_MAX_ENEMY_SPEED, CONSTANTS.MOVE_MAX_ENEMY_SPEED);
        randomGenerator();
    }
    public new void Start()
    {
        set();
        resetColor();
        travel = new Vector2(xMove, yMove);
    }
    public void Update()
    {
        transform.Translate(speed * travel * Time.deltaTime);
    }

    public void random_direction()
    {
        // movement being negativ , none , postivve
        xMove = Random.Range(-1, 2);
        yMove = Random.Range(-1, 2);
    }
    public void random_speed()
    {
        speed = Random.Range(-CONSTANTS.MOVE_MAX_ENEMY_SPEED, CONSTANTS.MOVE_MAX_ENEMY_SPEED);
    }

    public void randomGenerator()
    {
        random_direction();
        random_speed();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            if (xMove == -1 && yMove == -1)
            {
                xMove = -xMove;
                yMove = -yMove;
            }
            else if (xMove == -1 && yMove == 0)
            {
                xMove = -xMove;
                yMove = -xMove;
            }
            else if (xMove == -1 && yMove == 1)
            {
                xMove = -xMove;
                yMove = -yMove;
            }

            if (xMove == 0 && yMove == -1)
            {
                xMove = yMove;
                yMove = -yMove;
            }
            else if (xMove == 0 && yMove == 0)
            {
                random_direction();
            }
            else if (xMove == 0 && yMove == 1)
            {
                xMove = yMove;
                yMove = -yMove;
            }

            if (xMove == 1 && yMove == -1)
            {
                xMove = -xMove;
                yMove = -yMove;
            }
            else if (xMove == 1 && yMove == 0)
            {
                xMove = -xMove;
                yMove = -xMove;
            }
            else if (xMove == 1 && yMove == 1)
            {
                xMove = -xMove;
                yMove = -yMove;
            }
            travel = new Vector2(xMove, yMove);
        }
    }
}