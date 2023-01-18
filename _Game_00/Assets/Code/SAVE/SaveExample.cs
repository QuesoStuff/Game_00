using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal Clock timer;


    // Update is called once per frame
    void set()
    {
        mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        timer = GameObject.Find("Timer").GetComponent<Clock>();
    }
    void Start()
    {
        set();
        LoadGame();
        InvokeRepeating("SaveGame", 30f, 30f);
    }

    void Update() 
    {
    }

    private void SaveGame() 
    {
        SaveData saveData = new SaveData();  
        saveData.MAX_SCORE =  (int)Mathf.Max( saveData.MAX_SCORE , mainScript.Score.score) ;
        saveData.MAX_DISTANCE =  (int)Mathf.Max( saveData.MAX_DISTANCE , mainScript.total_Distance_traveled) ;
        saveData.MAX_KILLS =  (int)Mathf.Max( saveData.MAX_KILLS , mainScript.killCount) ;
        saveData.MAX_TIME_LASTED =  (int)Mathf.Min( saveData.MAX_TIME_LASTED , timer.timeStart) ;
        SaveManager.SaveGameState(saveData);
        Debug.Log("Game Saved!"); 
    }


    private void LoadGame() {
        SaveData saveData = SaveManager.LoadGameState();
        if(saveData != null) 
        {
            mainScript.Score.highScore = saveData.MAX_SCORE;
            Debug.Log("Game Loaded!");
        }
    }
}