using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Random_Level_Gen 
{

    [SerializeField] internal static GameObject enemy;
    [SerializeField] internal static GameObject item;
    [SerializeField] internal static GameObject wall;
    [SerializeField] internal static GameObject wall_moving;
    [SerializeField] internal static GameObject door;


    [SerializeField] internal static int enemy_Count;
    [SerializeField] internal static int item_Count;
    [SerializeField] internal static int wall_Count;
    [SerializeField] internal static int door_Count;
    [SerializeField] internal static int total_Count;

    [SerializeField] internal static float enemy_timer;
    [SerializeField] internal static float item_timer;
    [SerializeField] internal static float wall_timer;
    [SerializeField] internal static float door_timer;

    [SerializeField] internal static Transform player_Transform;

    [SerializeField] internal static Vector3 player_position;

    [SerializeField] internal static Vector3 enemy_position;
    [SerializeField] internal static Vector3 item_position;
    [SerializeField] internal static Vector3 wall_position;
    [SerializeField] internal static Vector3 door_position;


    [SerializeField] internal static int TOTAL_SPAWN_OBJECT_COUNT = 120;
    [SerializeField] internal static float ENEMY_TIMER_START = 20.0f;
    [SerializeField] internal static float ENEMY_TIMER_MINUS = 1.75F;
    [SerializeField] internal static float MIN_TIME_ENEMY_SPAWN = 3f;
    [SerializeField] internal static float ENEMY_TIME_BOUND = 7f;

    [SerializeField] internal static float ITEM_TIMER_START = 0.01f;
    [SerializeField] internal static float ITEM_TIMER_PLUS = 6.5f;
    [SerializeField] internal static float MAX_TIME_ITEM_SPAWN = 100.3f;
    [SerializeField] internal static float ITEM_TIME_BOUND = 80.3f;

    [SerializeField] internal static float WALL_TIMER_START = 12f;
    [SerializeField] internal static float WALL_TIMER_MINUS = 0.05f;
    [SerializeField] internal static float MIN_TIME_WALL_SPAWN = 5.3f;
    [SerializeField] internal static float WALL_TIME_BOUND = 2.3f;


    [SerializeField] internal static float DOOR_TIMER_START = 35f;
    [SerializeField] internal static float DOOR_TIMER_PLUS = 40;
    [SerializeField] internal static float MAX_TIME_DOOR_SPAWN = 600;
    [SerializeField] internal static float DOOR_TIME_BOUND = 480;
    public static void set()
    {
        setComponent();
        enemy_Count = item_Count = wall_Count = total_Count = 0;
        enemy_timer = ENEMY_TIMER_MINUS;
        item_timer = ITEM_TIMER_START;
        wall_timer = WALL_TIMER_START;
        door_timer = DOOR_TIMER_START;

    }
    // Start is called before the first frame update

    public static void setComponent()
    {
        enemy = (GameObject)Resources.Load("R_Enemy");
        item = (GameObject)Resources.Load("R_Item");
        wall = (GameObject)Resources.Load("wall");
        wall_moving = (GameObject)Resources.Load("R_Wall");
        door = (GameObject)Resources.Load("R_Door");

    }






    // Update is called once per frame

    public static void change_Time_enemy()
    {
        enemy_timer -= ENEMY_TIMER_MINUS;
        if (enemy_timer < MIN_TIME_ENEMY_SPAWN)
            enemy_timer = ENEMY_TIME_BOUND;
    }
    public static void change_Time_item()
    {
        item_timer += ITEM_TIMER_PLUS;
        if (item_timer > MAX_TIME_ITEM_SPAWN)
            item_timer = ITEM_TIME_BOUND;
    }
    public static void change_Time_wall()
    {
        enemy_timer -= WALL_TIMER_MINUS;
        if (enemy_timer < MIN_TIME_WALL_SPAWN)
            enemy_timer = WALL_TIME_BOUND;
    }

    public static void change_Time_door()
    {
        door_timer += DOOR_TIMER_PLUS;
        if (door_timer > MAX_TIME_DOOR_SPAWN)
            door_timer = DOOR_TIME_BOUND;
    }
    public static void change_timer_all()
    {
        change_Time_door();
        change_Time_wall();
        change_Time_item();
        change_Time_enemy();
    }

    public static IEnumerator spawnn_all()
    {
        while (total_Count < TOTAL_SPAWN_OBJECT_COUNT)
        {
            yield return new WaitForSeconds(enemy_timer);
            if (total_Count % 2 == 0)
                enemy_position = randomSpawn();
            else
                enemy_position = rangedSpawn_target();
            GameObject new_Enemy = Object.Instantiate(enemy, enemy_position, Quaternion.identity);
            enemy_Count++;
            total_Count++;
            yield return new WaitForSeconds(wall_timer);
            if (total_Count % 2 == 0)
                wall_position = randomSpawn();
            else
                wall_position = rangedSpawn_target();
            if (total_Count % 4 == 0 || total_Count % 5 == 0)
            {
                GameObject new_Wall = Object.Instantiate(wall_moving, wall_position, Quaternion.identity);
            }
            else
            {
                GameObject new_Wall = Object.Instantiate(wall, wall_position, Quaternion.identity);
            }
            wall_Count++;
            total_Count++;
            yield return new WaitForSeconds(item_timer);
            if (total_Count % 2 == 0)
                item_position = rangedSpawn_target();
            else
                item_position = randomSpawn();
            GameObject new_item = Object.Instantiate(item, item_position, Quaternion.identity);
            item_Count++;
            total_Count++;
            yield return new WaitForSeconds(door_timer);
            if (total_Count % 6 == 0)
                door_position = rangedSpawn_target();
            else
                door_position = randomSpawn();
            GameObject new_door = Object.Instantiate(door, door_position, Quaternion.identity);
            new_door.transform.rotation = Random.rotation;
            door_Count++;
            total_Count++;
            change_timer_all();
        }
    }

    public static IEnumerator spawn_enemy()
    {
        while (total_Count < TOTAL_SPAWN_OBJECT_COUNT)
        {
            yield return new WaitForSeconds(enemy_timer);
            if (total_Count % 2 == 0)
                enemy_position = randomSpawn();
            else
                enemy_position = rangedSpawn_target();
            GameObject new_Enemy = Object.Instantiate(enemy, enemy_position, Quaternion.identity);
            enemy_Count++;
            total_Count++;
            change_Time_enemy();

        }
    }

    public static IEnumerator spawn_wall()
    {
        while (total_Count < TOTAL_SPAWN_OBJECT_COUNT)
        {
            yield return new WaitForSeconds(wall_timer);
            if (total_Count % 2 == 0)
                wall_position = randomSpawn();
            else
                wall_position = rangedSpawn_target();
            if (total_Count % 4 == 0 || total_Count % 5 == 0)
            {
                GameObject new_Wall = Object.Instantiate(wall_moving, wall_position, Quaternion.identity);
            }
            else
            {
                GameObject new_Wall = Object.Instantiate(wall, wall_position, Quaternion.identity);
            }
            wall_Count++;
            total_Count++;
            change_Time_wall();

        }
    }

    public static IEnumerator spawn_item()
    {
        while (total_Count < TOTAL_SPAWN_OBJECT_COUNT)
        {
            yield return new WaitForSeconds(item_timer);
            if (total_Count % 2 == 0)
                item_position = rangedSpawn_target();
            else
                item_position = randomSpawn();
            GameObject new_item = Object.Instantiate(item, item_position, Quaternion.identity);
            item_Count++;
            total_Count++;
            change_Time_item();
        }
    }

    public static IEnumerator spawn_door()
    {
        while (total_Count < TOTAL_SPAWN_OBJECT_COUNT)
        {
            yield return new WaitForSeconds(door_timer);
            if (total_Count % 6 == 0)
                door_position = rangedSpawn_target();
            else
                door_position = randomSpawn();
            GameObject new_door = Object.Instantiate(door, door_position, Quaternion.identity);
            new_door.transform.rotation = Random.rotation;
            door_Count++;
            total_Count++;
            change_Time_item();
        }
    }

    public static Vector3 randomSpawn()
    {
        Vector3 location = Vector2.zero;
        var x = Random.Range(CONSTANTS.TESTROOM_X_AXIS_MIN, CONSTANTS.TESTROOM_X_AXIS_MAX);
        var y = Random.Range(CONSTANTS.TESTROOM_Y_AXIS_MIN, CONSTANTS.TESTROOM_Y_AXIS_MAX);
        location.x = x;
        location.y = y;
        return location;
    }
    public static Vector3 rangedSpawn_target()
    {
        Vector3 location = Vector2.zero;
        var x = Random.Range(CONSTANTS.PLAYER_X_AXIS_MIN, CONSTANTS.PLAYER_X_AXIS_MAX);
        var y = Random.Range(CONSTANTS.PLAYER_Y_AXIS_MIN, CONSTANTS.PLAYER_Y_AXIS_MAX);
        player_Transform = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<Transform>();
        player_position = player_Transform.position;
        if ((x+y)%2 == 0)
        {
        location.x = player_position.x + x; 
        location.y = player_position.y + y;
        }
        else
        {
        location.x = player_position.x - x; 
        location.y = player_position.y - y;
        }
        // wrap it around
        location.x = (location.x % CONSTANTS.PLAYER_X_AXIS_MAX) + CONSTANTS.PLAYER_X_AXIS_MIN;
        location.y = (location.y % CONSTANTS.PLAYER_Y_AXIS_MAX) + CONSTANTS.PLAYER_Y_AXIS_MIN;
        return location;
    }


}
