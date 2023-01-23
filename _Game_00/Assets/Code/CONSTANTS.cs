
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONSTANTS //: MonoBehaviour
{
    // CURRENTLY IN USE 
    // NOT YET IN USE


    //  MOVEMENTS SPEED
    // LEFT/RIGHT/UP/DOWN
    public const int MOVE_DEFAULT_SPEED = 5;
    public const float MOVE_DEFAULT_SPEED_DIAGONAL = 3.53553390593f; // (5 / sqrt(2))
    //more detailed movement speeds
    public const int MOVE_DEFAULT_X_AXIS_SPEED = 5;
    public const int MOVE_DEFAULT_Y_AXIS_SPEED = 5;
    public const int MOVE_DEFAULT_X_AXIS_SPEED_SLOW = 2;
    public const int MOVE_DEFAULT_Y_AXIS_SPEED_SLOW = 2;

    public const int MOVE_DEFAULT_X_AXIS_SPEED_FAST = 7;
    public const int MOVE_DEFAULT_Y_AXIS_SPEED_FAST = 7;

    public const int MOVE_DEFAULT_X_AXIS_SPEED_DASH = 6;
    public const int MOVE_DEFAULT_Y_AXIS_SPEED_DASH = 6;
    public const int MOVE_NONE = 0;
    public const int MOVE_MAX_ENEMY_SPEED = 7;
    // TIMERS
    // movement timer
    public const float DASH_TIME_QUICK = 0.05f;
    public const float DASH_TIME = 0.33f;
    // SHOOTING TIMER
    public const float CHARGED_SHOT_TIME = 1.8f;
        // INPUT TIMER VALUES
    public const float INPUT_DIRECTION_SHORT_PRESS_TIME = 0.0005f;
    public const float INPUT_DIRECTION_LONG_PRESS_TIME = 0.015f;
    public const float INPUT_ACTION_SHORT_PRESS_TIME_A = 0.0005f;
    public const float INPUT_ACTION_SHORT_PRESS_TIME_B = 0.0005f;
    public const float INPUT_ACTION_LONG_PRESS_TIME_A = 0.015f;
    public const float INPUT_ACTION_LONG_PRESS_TIME_B = 0.015f;
    public const float CHARGED_SHOT_TIME_READY = 2.3f;







    public const float ENEMY_TO_PLAYER_PROXY = 0.95f;


    // ANIMATION STATES (IDDLE & RUNNING)
    public const int ANIMATION_LEFT_IDDLE = 0;
    public const int ANIMATION_LEFT_RUN = 1;
    public const int ANIMATION_RIGHT_IDDLE = 2;
    public const int ANIMATION_RIGHT_RUN = 3;
    public const int ANIMATION_UP_IDDLE = 4;
    public const int ANIMATION_UP_RUN = 5;
    public const int ANIMATION_DOWN_IDDLE = 6;
    public const int ANIMATION_DOWN_RUN = 7;
    public const int ANIMATION_NO_PRESS = 8;
    // ADD CASES FOR SLOW/FAST , DOUBLE TAP MOVMENTS

    // CALCULATING LAST INDEX & LENGTH OF ANIME ARRAY
    public const int ANIMATION_LAST_ANIME_STATE_INDEX = ANIMATION_NO_PRESS;
    public const int ANIMATION_PLAYER_ANIME_COUNT = ANIMATION_LAST_ANIME_STATE_INDEX + 1; //last index +1 = array length 
    // COLLISION 
    // regarding HP (hurt or heal)
    public const int HP_DEFAULT_DAMAGE = 1;
    public const int HP_DEFAULT_HEALTH = 1;
    public const int HP_DEFAULT_MAX_HP_INCREASE = 1;
    public const int HP_DEFAULT_STARTER_HP = 10;
    public const int ENEMY_HP_MAX = 10;
    public const int ENEMY_DAMAGE_MAX = 4;



    // regarding collectables (items to search for)

    // ITEM GENERAL 
    //public const int TOTAL_ITEMS_TO_COLLECT = 8;
    //public const int PLAYER_NO_COLLECTION = 0;
    // SCORE GENERAL
    public const int SCORE_STARTING_PLAYER_SCORE = 0;
    public const int SCORE_DEFAULT_INCREMENT = 1;
    public const int SCORE_DEFAULT_DECREMENT = -1;
    public const int SCORE_RANGE_MIN = -5;
    public const int SCORE_RANGE_MAX = 7;



    public const int SCORE_DEFUALT_OF_ITEM_PICKUP = 5;
    public const int SCORE_DEFUALT_OF_COLLECTION_PICKUP = 7;
    // COLLISION TAGS
    public const string COLLISION_TAG_PLAYER = "Player";
    public const string COLLISION_TAG_WALL = "wall";
    public const string COLLISION_TAG_ITEM = "item";
    public const string COLLISION_TAG_ITEM_SCORE = "itemScore";
    public const string COLLISION_TAG_ITEM_HP = "itemHP";
    public const string COLLISION_TAG_ENEMY = "enemy";
    public const string COLLISION_TAG_EXPLOSION = "explosion";
    public const string COLLISION_TAG_BULLET = "bullet";
    public const string COLLISION_TAG_TELEPORT = "teleport";
    public const string COLLISION_TAG_COLLECTABLE = "collectable";
    public const string COLLISION_TAG_CLOCK = "Clock";
    public const string COLLISION_TAG_REPEAT = "REPEAT";

    // ENEMY MOVING CONFIG
    public const int ENEMY_MOVE_COUNT = 47;
    public const int ENEMY_MOVEMENT_COPY = 0;
    public const int ENEMY_MOVEMENT_COPY_DIAGONAL = 1;
    public const int ENEMY_MOVEMENT_COPY_REVERSE = 2;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL = 3;
    public const int ENEMY_MOVEMENT_WEIRD = 4;
    public const int ENEMY_MOVEMENT_FOLLOW = 5;
    public const int ENEMY_MOVEMENT_COPY_CONTINUE = 6;
    public const int ENEMY_MOVEMENT_COPY_DIAGONAL_CONTINUE = 7;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_CONTINUE = 8;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_CONTINUE = 9;
    public const int ENEMY_MOVEMENT_WEIRD_CONTINUE = 10;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER = 11;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_X = 12;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_Y = 13;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_INV = 14;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_0 = 15;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_1 = 16;
    public const int ENEMY_MOVEMENT_FOLLOW_SCATTER_INV_NEG_2 = 17;
    public const int ENEMY_MOVEMENT_FOLLOW_KEEP = 18;
    public const int ENEMY_MOVEMENT_WEIRD_2 = 19;
    // added with the release keys added
    public const int ENEMY_MOVEMENT_COPY_2 = 20;
    public const int ENEMY_MOVEMENT_COPY_DIAGONAL_2 = 21;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_2 = 22;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_2 = 23;
    public const int ENEMY_MOVEMENT_WEIRD_2_2 = 24;
    public const int ENEMY_MOVEMENT_WEIRD_FOLLOW_2 = 25;
    public const int ENEMY_MOVEMENT_COPY_CONTINUE_2 = 26;
    public const int ENEMY_MOVEMENT_COPY_DIAGONAL_CONTINUE_2 = 27;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_CONTINUE_2 = 28;
    public const int ENEMY_MOVEMENT_COPY_REVERSE_DIAGONAL_CONTINUE_2 = 29;
    public const int ENEMY_MOVEMENT_WEIRD_2_ = 30;
    public const int ENEMY_MOVEMENT_FOLLOW_STOP_0 = 31;
    public const int ENEMY_MOVEMENT_FOLLOW_STOP_1 = 32;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_0 = 33;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_1 = 34;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_2 = 35;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_3 = 36;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_4 = 37;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_5 = 38;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_6 = 39;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_0 = 40;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_1 = 41;
    public const int ENEMY_MOVEMENT_FOLLOW_SCARED_INPUT_2 = 42;
    public const int ENEMY_MOVE_FULL_KEY_0 = 43;
    public const int ENEMY_MOVE_FULL_KEY_1 = 44;
    public const int ENEMY_MOVE_FULL_KEY_2 = 45;
    public const int ENEMY_MOVE_FULL_KEY_3 = 46;


    // EXPLOSION PARTICLE AFFECT (MIN/MAX RANGE)
    public const int EXPLOSION_SIM_SPEED_MIN = 1;
    public const int EXPLOSION_SIM_SPEED_MAX = 5;
    public const float EXPLOSION_SIM_START_SIZE_MIN = 0.1f;
    public const float EXPLOSION_SIM_START_SIZE_MAX = 0.3f;
    public const int EXPLOSION_PARTICLE_COUNT_MIN = 150;
    public const int EXPLOSION_PARTICLE_COUNT_MAX = 1000;
    public const float EXPLOSION_END_LIFE_MIN = 0.5f;
    public const float EXPLOSION_END_LIFE_MAX = 1.5f;
    public const float EXPLOSION_DURATION_MIN = 0.5f;
    public const float EXPLOSION_DURATION_MAX = 2.7f;
    // EXPLOSION PARTICLE AFFECT bullet
    public const int BULLET_SIM_SPEED_MIN = 2;
    public const int BULLET_SIM_SPEED_MAX = 6;
    public const float BULLET_SIM_START_SIZE_MIN = 0.07f;
    public const float BULLET_SIM_START_SIZE_MAX = 0.2f;
    public const int BULLET_PARTICLE_COUNT_MIN = 1;
    public const int BULLET_PARTICLE_COUNT_MAX = 10;
    public const float BULLET_END_LIFE_MIN = 0.5f;
    public const float BULLET_END_LIFE_MAX = 1.5f;
    public const float BULLET_DURATION_MIN = 0.05f;
    public const float BULLET_DURATION_MAX = 0.25f;




    // item default score (MIN/MAX RANGE)
    public const int ITEM_MINIMUM_SCORE = 1;
    public const int ITEM_MAXIMUM_SCORE = 25;

    public const int ITEM_MINIMUM_HP = 1;
    public const int ITEM_MAXIMUM_HP = 8;

    // SPAWNING STUFF (IN RELATION TO PLAYER'S POSITION)
    public const int ITEM_OFFSET_X_AXIS_MIN = -5;
    public const int ITEM_OFFSET_X_AXIS_MAX = 5;
    public const int ITEM_OFFSET_Y_AXIS_MIN = -5;
    public const int ITEM_OFFSET_Y_AXIS_MAX = 5;

    public const int ENEMY_DEFAULT_SPEED = 5;

    public const float ENEMY_OFFSET_X_AXIS_MIN = -1.5f;
    public const float ENEMY_OFFSET_X_AXIS_MAX = 1.5f;
    public const float ENEMY_OFFSET_Y_AXIS_MIN = -1.5f;
    public const float ENEMY_OFFSET_Y_AXIS_MAX = 1.5f;

    public const float RESPAWN_ITEM_IF_WALL_COLLISION = 0.5f;
    public const int MAX_ITEMS_COUNT = 25;
    public const int MAX_ENEMY_COUNT = 75;

    // THE TESTING ROOM SPECS
    // DURATION OF GAME SESSION (IN RELATION TO THE TESTING ROOM)
    public const int TIME_IN_LEVEL = 1200;
    public const int TIME_IN_LEVEL_HALF_WAY = TIME_IN_LEVEL / 2;
    public const int TIME_IN_LEVEL_LOW = 60;
    // TEST ROOM DIMENSIONS (SURVIVAL ROOM SURIVVAL MODE)
    public const int TESTROOM_X_AXIS_MIN = -50;  //-65 
    public const int TESTROOM_X_AXIS_MAX = 50;   //65
    public const int TESTROOM_Y_AXIS_MIN = -50;  //-31
    public const int TESTROOM_Y_AXIS_MAX = 50;  //31

    public const int PLAYER_X_AXIS_MIN = -50;  //-65 
    public const int PLAYER_X_AXIS_MAX = 50;   //65
    public const int PLAYER_Y_AXIS_MIN = -50;  //-31
    public const int PLAYER_Y_AXIS_MAX = 50;  //31

    // BULLET TYPE COUNT LIMIT
    public const int BULLET_COUNT_0 = 7;
    public const int BULLET_COUNT_1 = 15;
    public const int BULLET_COUNT_2 = 25;
    public const int BULLET_COUNT_3 = 30;





    /* COLOR
     public  Color DEFAULT_WHITE_COLOR = Color.white;
     public  Color DEFAULT_BLACK_COLOR = Color.black;
     public   Color DEFAULT_WALL_COLOR = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
     public  Color DEFAULT_PLAYER_COLOR = new Color(0.4588f, 0.8198f, 0.6941f, 1);
     public   Color DEFAULT_PLAYER_COLOR_HURT = new Color(0.4588f, 0.8198f, 0.6941f, 1);
     public   Color DEFAULT_PLAYER_COLOR_DASH = new Color(0.4588f, 0.8198f, 0.6941f, 1);
     public  Color DEFAULT_PLAYER_COLOR_COLLISION = new Color(0.4588f, 0.8198f, 0.6941f, 1);
     public   Color DEFAULT_BACKGROUND_COLOR = new Color(0.238392f, 0.2047437f, 0.4056604f, 0);
        // bullet colors
    public  Color BULLET_COLOR_SPEED_0 = new Color(0.4588f, 0.8198f, 0.6941f, 1); // greeen 
    public   Color BULLET_COLOR_SPEED_1 = new Color(0.0811f, 0.7202f, 0.9056f, 1); //blue
    public  Color BULLET_COLOR_SPEED_2 = new Color(0.9056f, 0.6538f, 0.0811f, 1); //orange
    public  Color BULLET_COLOR_SPEED_3 = new Color(0.9056f, 0.2959f, 0.0811f, 1); //red

    */
    public const float DEFAULT_FLASH_TIME = 0.3f;

    public const int DEFAULT_KNOCKBACK = 5000;


    public const int DEFAULT_WALL_SPEED_MIN = -10;
    public const int DEFAULT_WALL_SPEED_MAX = 10;

    // R-G-B-Bl-Wh
    public const int COLOR_CHOICES = 5;



}
