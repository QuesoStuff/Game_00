using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MAIN_GAME_OBJECT_SCRIPT
{
    // UNITY FIELD OBJECTS
    [SerializeField] internal int scoreAdded;
    [SerializeField] internal int HP_Added;
    [SerializeField] internal float positionOffset;
    [SerializeField] internal Object explosionRef;
    [SerializeField] internal EXPLOSION ex;
    [SerializeField] internal BoxCollider2D col;

    //[SerializeField] internal RespawnScript respawnScript;



    // SET & CONSTRUCTOR
    public void setRef()
    {
        explosionRef = Resources.Load("explosion_item");
        ex = GetComponent<EXPLOSION>();
        //respawnScript = GameObject.Find(CONSTANTS.COLLISION_TAG_REPEAT).GetComponent<RespawnScript>();
        col = GetComponent<BoxCollider2D>();
    }
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_ITEM;
        base.set();
        setRef();
        transform.rotation = Random.rotation;
        spriterender.color += new Color(1, (float)HP_Added / (float)CONSTANTS.ITEM_MAXIMUM_HP, (float)scoreAdded / (float)CONSTANTS.ITEM_MAXIMUM_SCORE, 1);
        positionOffset = CONSTANTS.RESPAWN_ITEM_IF_WALL_COLLISION;
        this.scoreAdded = CONSTANTS.SCORE_DEFAULT_INCREMENT;
        this.HP_Added = CONSTANTS.HP_DEFAULT_HEALTH;
    }
    void Start()
    {
        set();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_PLAYER))
        {
            GetComponent<AudioSource>().Play();
            ex.explosionCreate(explosionRef, transform.position, spriterender.color);
            //Destroy(gameObject,  GetComponent<AudioSource>().clip.length);
            Destroy(gameObject, 0.3f);

        }
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            Vector3 offsetVector = Vector2.zero;
            var x = Random.Range(CONSTANTS.TESTROOM_X_AXIS_MIN, CONSTANTS.TESTROOM_X_AXIS_MAX);
            var y = Random.Range(CONSTANTS.TESTROOM_Y_AXIS_MIN, CONSTANTS.TESTROOM_Y_AXIS_MAX);
            offsetVector.x = x;
            offsetVector.y = y;
            transform.position = offsetVector;
        }
    }

    void OnDestroy()
    {
        //respawnScript.itemCreatedCount--;
        Random_Level_Gen.item_Count--;
    }
}
