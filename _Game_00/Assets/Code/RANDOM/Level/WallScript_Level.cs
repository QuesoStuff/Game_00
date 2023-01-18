using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript_Level : WallScript, I_LEVEL
{

    [SerializeField] internal float xMove;
    [SerializeField] internal float yMove;
    [SerializeField] internal Vector2 travel;
    [SerializeField] internal float speed;
    [SerializeField] internal int interval;

    [SerializeField] internal Color startingColor;

    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ENEMY;
        spriterender = GetComponent<SpriteRenderer>();
        startingColor = spriterender.color;
        base.set();
        gameObject.tag = CONSTANTS.COLLISION_TAG_WALL;
        level_generator();
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

    public void level_generator()
    {
        level_speed_select();
    }

    public void level_speed_select()
    {
        interval = CONSTANTS.MOVE_MAX_ENEMY_SPEED / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
            speed = Random.Range(0 * interval, 1 * interval);
        else if (startingColor == Color.green)
            speed = Random.Range(1 * interval, 2 * interval);
        else if (startingColor == Color.blue)
            speed = Random.Range(2 * interval, 3 * interval);
        else if (startingColor == Color.black)
            speed = Random.Range(3 * interval, 4 * interval);
        else if (startingColor == Color.white)
            speed = Random.Range(4 * interval, 5 * interval);
    }
    public void level_collision_select()
    {
        interval = CONSTANTS.MOVE_MAX_ENEMY_SPEED / CONSTANTS.COLOR_CHOICES;
        if (startingColor == Color.red)
            xMove = speed;
        else if (startingColor == Color.green)
            yMove = speed;
        else if (startingColor == Color.blue)
        {
            xMove = speed;
            yMove = speed;
        }
        else if (startingColor == Color.black)
        {
            xMove = -speed;
            yMove = speed;
        }
        else if (startingColor == Color.white)
        {
            xMove = speed;
            yMove = -speed;
        }
        else
        {
            xMove = -speed;
            yMove = -speed;
        }
        travel = new Vector2(xMove, yMove);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            level_collision_select();
        }
    }
}