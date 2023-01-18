using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Health : HEALTH
{

    [SerializeField] internal _Player_Script player;
    [SerializeField] internal EnemyScript mainScript;
    [SerializeField] internal int damageToPlayer;

    [SerializeField] internal Object explosionRef;

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();
        player = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();

    }

    public void setRef()
    {
        explosionRef = Resources.Load("Explosion");
    }
    public new void set()
    {
        base.set();
        setRef();
        setComponent();
        damageToPlayer = CONSTANTS.ENEMY_DEFAULT_SPEED;
        HP = Random.Range(3, 5);
    }
    public override void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
            HP_Zero();
        else
            mainScript.Color.whiteFlash();
        //StartCoroutine(mainScript.Color.whiteFlash()); 
    }
    public override void HP_damage(int HP_damage)
    {
        HP -= HP_Damage;
        if (HP <= 0)
            HP_Zero();
        else
            mainScript.Color.whiteFlash();
        //StartCoroutine(mainScript.Color.whiteFlash()); 
    }


    public override void HP_Zero()
    {
        mainScript.Controller.speed /= 4;
        GetComponent<BoxCollider2D>().enabled = false;
        mainScript.spriterender.color = Color.white;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        mainScript.ex.explosionCreate(explosionRef, transform.position, mainScript.spriterender.color);
        // to make the enemy vanish
        mainScript.spriterender.enabled = false;
    }

    void OnDestroy()
    {
        player.killCount++;
        player.Score.scorechange();
        //mainScript.respawnScript.enemyCreatedCount--;
        mainScript.respawnScript.enemy_Count--;

    }
}

