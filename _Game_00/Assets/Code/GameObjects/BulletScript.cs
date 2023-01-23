using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// code in relation to bullet/projectile FIRST ONE
public class BulletScript : MAIN_GAME_OBJECT_SCRIPT
{
    // fields & variable creation
    [SerializeField] internal float speed;
    [SerializeField] internal float x;
    [SerializeField] internal float y;
    [SerializeField] internal int bullet_damge;

    [SerializeField] internal static int bulletShotCount;
    [SerializeField] internal Color currColor;
    [SerializeField] internal Color colorSpeed_0;
    [SerializeField] internal Color colorSpeed_1;
    [SerializeField] internal Color colorSpeed_2;
    [SerializeField] internal Color colorSpeed_3;
    [SerializeField] internal float lifeTime;
    [SerializeField] internal Object explosionRef;
    [SerializeField] internal Object explosionRef2;
    [SerializeField] internal EXPLOSION ex;

    [SerializeField] internal Vector2 bulletSpeed;
    [SerializeField] internal BoxCollider2D col;

    public void setRef()
    {
        explosionRef = Resources.Load("explosion_bullet_collision");
        explosionRef2 = Resources.Load("explosion_wall");
        ex = GetComponent<EXPLOSION>();
        col = GetComponent<BoxCollider2D>();

    }
    public new void set()
    {
        gameObject.tag = CONSTANTS.COLLISION_TAG_BULLET;
        setRef();
        base.set();
        speed = 5;
        lifeTime = 3.21f;
        BulletScript.bulletShotCount++;
        Destroy(gameObject, 4 * lifeTime);
        Invoke("changeCounter", lifeTime);
        bullet_damge = 1;
        colorSet();
    }
    void colorSet()
    {
        colorSpeed_0 = new Color(0.4588f, 0.8198f, 0.6941f, 1); // greeen 
        colorSpeed_1 = new Color(0.0811f, 0.7202f, 0.9056f, 1); //blue
        colorSpeed_2 = new Color(0.9056f, 0.6538f, 0.0811f, 1); //orange
        colorSpeed_3 = new Color(0.9056f, 0.2959f, 0.0811f, 1); //red
    }
    void Start()
    {
        set();
        bulletColor();
        bullet_Direction();
    }
    void changeCounter()
    {
        if (bulletShotCount > 0)
            BulletScript.bulletShotCount--;
    }
    void bullet_Direction()
    {
        if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
        {
            rb2d.velocity = new Vector2(x, y) * speed;
            bulletSpeed = new Vector2(x, y) * speed;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
        {
            rb2d.velocity = new Vector2(x, y) * speed / 2;
            bulletSpeed = new Vector2(x, y) * speed / 2;
        }
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
        {
            rb2d.velocity = new Vector2(x, y) * speed / 2;
            bulletSpeed = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(x, y) * speed / 4;
            bulletSpeed = Vector2.zero;
        }
    }
    void bulletColor()
    {
        if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_0)
            currColor = colorSpeed_0;
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_1)
            currColor = colorSpeed_1;
        else if (BulletScript.bulletShotCount < CONSTANTS.BULLET_COUNT_2)
        {
            currColor = colorSpeed_2;
            bullet_damge = 2;
        }
        else
        {
            currColor = colorSpeed_3;
            bullet_damge = 3;
        }
        spriterender.color = currColor;
    }

    // happen when bullet is destroyed
    void OnDestroy()
    {
        changeCounter();
    }

    void Update()
    {
    }
    private void FixedUpdate() // MORE EFFICIENT version of update method (every frame)
    {
        rb2d.velocity += bulletSpeed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, lifeTime);
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            ex.explosionCreate(explosionRef, transform.position, other.gameObject.GetComponent<SpriteRenderer>().color);
            spriterender.color = currColor;
            bulletSpeed = new Vector2(x / 2, y / 2);
            Destroy(gameObject, 1.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == CONSTANTS.COLLISION_TAG_ENEMY)
        {
            GetComponent<AudioSource>().Play();
            ex.explosionCreate(explosionRef, transform.position, other.gameObject.GetComponent<SpriteRenderer>().color);
            //Destroy(gameObject,  GetComponent<AudioSource>().clip.length);
            Destroy(gameObject, 0.3f);

        }


        if (other.CompareTag(CONSTANTS.COLLISION_TAG_WALL))
        {
            ex.explosionCreate(explosionRef2, transform.position, other.gameObject.GetComponent<SpriteRenderer>().color);
            spriterender.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            bulletSpeed = new Vector2(-x / 8, -y / 8);
        }
        else if (other.CompareTag(CONSTANTS.COLLISION_TAG_ITEM))
        {
            var temp = x;
            x = -2 * y;
            y = -temp / 2;
        }
    }


}

