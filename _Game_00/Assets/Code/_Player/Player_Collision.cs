
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MAIN_GAME_OBJECT_SCRIPT
{

    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal int pushBack;

    public void setComponent()
    {
        //mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        mainScript = GetComponent<_Player_Script>();

    }
    public new void set()
    {
        base.set();
        setComponent();
        pushBack = 5000;

    }

    public void collisionWith_Enemy(Collision2D collision)
    {
        Vector2 direction = (collision.gameObject.transform.position - transform.position).normalized;
        rb2d.AddForce(-pushBack * direction);
    }
    public void collisionWith_Enemy_EXIT(Collision2D collision)
    {
        //flash();
        mainScript.SFX.audioHurt();
        mainScript.HP.HP_damage(collision.gameObject.GetComponent<Enemy_Health>().damageToPlayer);
        StartCoroutine(mainScript.Color.flash(mainScript.Color.DEFAULT_PLAYER_COLOR_HURT , 0.1f));
    }
    public void collisionWith_Door(Collider2D other)
    {
        transform.position = other.gameObject.GetComponent<DoorScript>().teleport.position;
    }
    public void collsionWith_Item(Collider2D other)
    {
        ItemScript item = other.gameObject.GetComponent<ItemScript>();
        ScoreManager.scoreChange(item.scoreAdded);
        mainScript.HP.HP_heal(item.HP_Added);
        if (item.HP_Added> item.scoreAdded)
        {
            StartCoroutine(mainScript.Color.flashing(mainScript.Color.DEFAULT_PLAYER_COLOR_HP_UP , 2 , 0.1f));
        }
        else
        {
            StartCoroutine(mainScript.Color.flashing(mainScript.Color.DEFAULT_PLAYER_COLOR_DASH , 2 , 0.1f));
        }


    }
    public void collisionWith_Wall(Collision2D collision)
    {
        Color newColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        spriterender.color = newColor;
    }
    public void collisionWith_Wall_EXIT(Collision2D collision)
    {
        mainScript.Color.Invoke("resetColor", 2.3f);
    }
}