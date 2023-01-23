using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GENERIC_UI : MonoBehaviour
{
    [SerializeField] internal Text textBox;
    [SerializeField] internal Color displayColor;
    [SerializeField] internal Color newDisplayColor;
    [SerializeField] internal SaveData saveFile;
    [SerializeField] internal bool newSaveData;

    [SerializeField] internal _Player_Script playerScript; // in secs







    // Use this for initialization
    public void setComponent()
    {
        textBox = GetComponent<Text>();
        playerScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        saveFile = SaveManager.saveFile;
    }

    public void setColor()
    {
        displayColor = Color.white;
        newDisplayColor = Color.yellow;
    }
    public void setTextColor(Color color)
    {
        textBox.color = color;
    }
    public void set()
    {
        newSaveData = false;
        setComponent();
        setColor();
        setTextColor(displayColor);
    }
    //void Start()
    //{set();}

    //void Update()
    //{display();}
}