using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManager
{

    [SerializeField] internal static _Player_Script mainScript;
    [SerializeField] internal static SaveData saveFile;

    public static void set()
    {
        mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        saveFile = LoadGameState();
    }
    public static void SaveGameState(SaveData saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.persistentDataPath + "/SaveData.save");
        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public static SaveData LoadGameState()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.save"))
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveData.save", FileMode.Open);
                SaveData saveData = (SaveData)binaryFormatter.Deserialize(file);
                file.Close();
                return saveData;
            }
            catch
            {

            }
        }
        SaveData newFile = new SaveData();
        newFile.set(Clock.START_TIME);
        return newFile;
        //return null;
    }

    public static void SaveGame()
    {
        // make new save file 
        saveFile.MAX_SCORE = (int)Mathf.Max(saveFile.MAX_SCORE, ScoreManager.score);
        saveFile.MAX_DISTANCE = (int)Mathf.Max(saveFile.MAX_DISTANCE, mainScript.total_Distance_traveled);
        saveFile.MAX_KILLS = (int)Mathf.Max(saveFile.MAX_KILLS, mainScript.killCount);
        saveFile.TIME_LEFT = (int)Mathf.Min(saveFile.TIME_LEFT, Clock.CurrentTime);
        saveFile.MAX_BULLET_COUNT = (int)Mathf.Max(saveFile.MAX_BULLET_COUNT, mainScript.bullet_shot_Count);
        SaveManager.SaveGameState(saveFile);
    }
}