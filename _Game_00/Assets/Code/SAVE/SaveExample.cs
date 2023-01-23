using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal SaveData saveFile;


    // Update is called once per frame
    void set()
    {
        mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
    }
    void Start()
    {
        set();
        LoadGame();
        //InvokeRepeating("SaveGame", 30f, 30f);
    }

    void Update() 
    {
    }

    public void SaveGame() 
    {
        // make new save file 
        saveFile.MAX_SCORE =  (int)Mathf.Max( saveFile.MAX_SCORE , ScoreManager.score) ;
        saveFile.MAX_DISTANCE =  (int)Mathf.Max( saveFile.MAX_DISTANCE , mainScript.total_Distance_traveled) ;
        saveFile.MAX_KILLS =  (int)Mathf.Max( saveFile.MAX_KILLS , mainScript.killCount) ;
        saveFile.TIME_LEFT =  (int)Mathf.Min( saveFile.TIME_LEFT , Clock.CurrentTime) ;
        saveFile.MAX_BULLET_COUNT =  (int)Mathf.Max( saveFile.MAX_BULLET_COUNT , mainScript.bullet_shot_Count) ;
        SaveManager.SaveGameState(saveFile);
        Debug.Log("Game Saved!"); 
    }


    public void LoadGame() 
    {
        saveFile = SaveManager.LoadGameState();
        if(saveFile != null) 
        {
            //mainScript.Score.highScore = saveData.MAX_SCORE;
            Debug.Log("Game Loaded!");
        }
    }
}