using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{

    [SerializeField] internal Player_Health HP;
    [SerializeField] internal int maxHP;
    [SerializeField] internal int currHP;

    [SerializeField] internal Color lifeBar;
    [SerializeField] internal SpriteRenderer spriterender; // graphical part, flips sprite if need be

    void set()
    {
        this.spriterender = gameObject.GetComponent<SpriteRenderer>();
        maxHP = HP.HP;
        lifeBar =  Color.green;
        spriterender.color = lifeBar;
    }
    void updateHP_Bar()
    {
        if (HP.HP / maxHP == 1) // green
        {
            lifeBar = Color.green;
            spriterender.color = lifeBar;
        }

        else if ((float)HP.HP / (float)maxHP >= 0.66f) // green
        {
            lifeBar = new Color(0.1450f, 0.6784f, 0.2627f, 1);
            spriterender.color = lifeBar;
        }
        else if ((float)HP.HP / (float)maxHP >= 0.33f) // yellow
        {
            lifeBar = new Color(0.6784f, 0.6274f, 0.1450f, 1);
            spriterender.color = lifeBar;
        }
        else // red 
        {
            lifeBar = new Color(0.6784f, 0.1450f, 0.2315f, 1);
            spriterender.color = lifeBar;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        set();
    }

    // Update is called once per frame
    void Update()
    {
        updateHP_Bar();
    }

}
