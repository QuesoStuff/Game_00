using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class RespawnScript : MonoBehaviour
{

    [SerializeField] internal GameObject enemy;
    [SerializeField] internal GameObject item;
    [SerializeField] internal Vector3 target;
    [SerializeField] internal Vector3 spawnLocation;


    [SerializeField] internal float enemyRespawnTime;
    [SerializeField] internal float enemyRespawnTimeDecrementor;
    [SerializeField] internal float enemyRespawnTimeMAX;
    [SerializeField] internal Vector3 enemySpawnLocation;
    [SerializeField] internal float x_Offset_enemy;
    [SerializeField] internal float y_Offset_enemy;
    [SerializeField] internal int enemyCreatedCount;



    [SerializeField] internal float itemRespawnTime;
    [SerializeField] internal float itemRespawnTimeIncrementor;
    [SerializeField] internal float itemRespawnTimeMAX;
    [SerializeField] internal Vector3 itemSpawnLocation;
    [SerializeField] internal int x_Offset_item;
    [SerializeField] internal int y_Offset_item;
    [SerializeField] internal int itemCreatedCount;

    [SerializeField] internal SpriteRenderer spriterender; // graphical part, flips sprite if need be


    void set()
    {
        setComponent();
        enemyRespawnTime = 1.2f;
        itemRespawnTime = 5f;
        enemyRespawnTimeDecrementor = 0.2f;
        itemRespawnTimeIncrementor = 0.5f;
        itemRespawnTimeMAX = 17.5f;
        enemyRespawnTimeMAX = 1.8f;
        x_Offset_item = 0;
        y_Offset_item = 0;
        x_Offset_enemy = 0;
        y_Offset_enemy = 0;
        enemyCreatedCount = 0;
        itemCreatedCount = 0;
        this.spriterender = gameObject.GetComponent<SpriteRenderer>();
        spriterender.enabled = false;

    }
    // Start is called before the first frame update

    public void setComponent()
    {
        enemy = (GameObject)Resources.Load(CONSTANTS.COLLISION_TAG_ENEMY);
        item = (GameObject)Resources.Load(CONSTANTS.COLLISION_TAG_ITEM);
    }



    void Start()
    {
        set();
        StartCoroutine(spawn(enemyRespawnTime, itemRespawnTime, enemy, item));
    }

    // Update is called once per frame
    public void Update()
    {

    }
    public void changeTime()
    {
        enemyRespawnTime -= enemyRespawnTimeDecrementor;
        if (enemyRespawnTime < enemyRespawnTimeMAX)
            enemyRespawnTime = enemyRespawnTimeMAX;

        itemRespawnTime += itemRespawnTimeIncrementor;
        if (itemRespawnTime > itemRespawnTimeMAX)
            itemRespawnTime = itemRespawnTimeMAX;
    }
    //public  void createSpawnLocationEnemy_Tracker();


    //public  void createSpawnLocationItem_Tracker();


    public Vector3 createSpawn()
    {
        Vector3 offsetVector = Vector2.zero;
        var x = Random.Range(CONSTANTS.TESTROOM_X_AXIS_MIN, CONSTANTS.TESTROOM_X_AXIS_MAX);
        var y = Random.Range(CONSTANTS.TESTROOM_Y_AXIS_MIN, CONSTANTS.TESTROOM_Y_AXIS_MAX);
        offsetVector.x = x;
        offsetVector.y = y;
        return offsetVector;
    }

    public IEnumerator spawn(float timeInterval_enemy, float timeInterval_item, GameObject spawnObject_enemy, GameObject spawnObject_item)
    {
        //if (itemCreatedCount < CONSTANTS.MAX_ITEMS_COUNT || enemyCreatedCount < CONSTANTS.MAX_ENEMY_COUNT)
        {
            while (true)
            {
                yield return new WaitForSeconds(timeInterval_enemy);
                enemySpawnLocation = createSpawn();
                GameObject new_Enemy = Instantiate(spawnObject_enemy, enemySpawnLocation, Quaternion.identity);
                yield return new WaitForSeconds(timeInterval_item);
                itemSpawnLocation = createSpawn();
                GameObject new_Item = Instantiate(spawnObject_item, itemSpawnLocation, Quaternion.identity);
                changeTime();
                itemCreatedCount++;
                enemyCreatedCount++;
            }
        }
    }
}
