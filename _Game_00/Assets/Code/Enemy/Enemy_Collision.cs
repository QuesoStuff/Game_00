using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Collision : MAIN_GAME_OBJECT_SCRIPT
{

    [SerializeField] internal EnemyScript mainScript;

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
    }

    public new void set()
    {
        setComponent();
        base.set();
    }

    public void collisionWith_Bullet(Collider2D other)
    {
        int damage = other.gameObject.GetComponent<BulletScript>().bullet_damge;
        mainScript.Health.HP_damage(damage);
    }
    public void collisionWith_Door(Collider2D other)
    {
        transform.position = other.gameObject.GetComponent<DoorScript>().teleport.position;
    }
    public void collisionWith_Player(Collision2D collision)
    {
        mainScript.Controller.speed /= 2;
        GameObject obj = collision.gameObject;
        Vector2 direction = (obj.transform.position - transform.position).normalized;
        rb2d.AddForce(-10000 * direction);
        Color color = obj.GetComponent<SpriteRenderer>().color;
        mainScript.Color.flash( color , 0.92f);

    }
    public void collisionWith_Wall(Collision2D collision)
    {
        //spriterender.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        rb2d.velocity = Vector2.zero;
        mainScript.Controller.speed /= 2;
        mainScript.Controller.Invoke("resetSpeed", 0.92f);

    }






}
