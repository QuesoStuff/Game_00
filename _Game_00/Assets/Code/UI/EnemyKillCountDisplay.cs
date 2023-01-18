using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKillCountDisplay : MonoBehaviour
{
    [SerializeField] internal Text textBox;
    [SerializeField] internal _Player_Script player;

    // Use this for initialization
    void set()
    {
        textBox.text = "X: " + player.killCount.ToString();
        textBox.color = Color.white;

    }
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        set();
    }
}