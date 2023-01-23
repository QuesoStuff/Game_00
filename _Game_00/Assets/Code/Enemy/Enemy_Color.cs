using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Color : COLOR
{
    [SerializeField] internal EnemyScript mainScript;
    [SerializeField] internal Color DEFAULT_ENEMY_COLOR;

    [SerializeField] internal float opacityDecrementer;
    [SerializeField] internal float RGB_Red_to_White;
    [SerializeField] internal float RGB_Green_to_White;
    [SerializeField] internal float RGB_Blue_to_White;
    [SerializeField] internal int starting_opacity;
    // defaultColor

    public void setComponent()
    {
        mainScript = GetComponent<EnemyScript>();

    }
    public void setRef()
    {
        // mainScript = (EnemyScript)Resources.Load("enemy").GetComponent<EnemyScript>(); 
    }
    void calculateColor0()
    {
        defaultColor.r = (float)mainScript.Health.damageToPlayer / (float)CONSTANTS.ENEMY_DAMAGE_MAX;
        defaultColor.g = (float)mainScript.Health.HP / (float)CONSTANTS.ENEMY_HP_MAX;
        defaultColor.b = (float)mainScript.Controller.speed / (float)CONSTANTS.MOVE_MAX_ENEMY_SPEED;
        defaultColor.a = starting_opacity;
        spriterender.color = defaultColor;
    }
    void calculateColor1()
    {
        opacityDecrementer = (float)starting_opacity / (float)mainScript.Health.HP;
        opacityDecrementer = -opacityDecrementer;
        RGB_Red_to_White = (1 - defaultColor.r) / (float)mainScript.Health.HP;
        RGB_Green_to_White = (1 - defaultColor.g) / (float)mainScript.Health.HP;
        RGB_Blue_to_White = (1 - defaultColor.b) / (float)mainScript.Health.HP;
    }



    public new void set()
    {
        base.set();
        starting_opacity = 1;
        setComponent();
        calculateColor0();
        calculateColor1();
        resetColor();
        spriterender.enabled = true;
        opacityDecrementer = 0;


    }
    /*
        public IEnumerator enemyFlash()
        {
            StartCoroutine(base.flash(Color.white, 3.5f));
            updateColor();
            resetColor();
            yield return null;
        }
        */

        // why can't I use subroutine
    public void whiteFlash()
    {
        spriterender.color = Color.white;
        Invoke("updateColor", 0.5f);
        updateColor();
        resetColor();
    }
    /*
        public IEnumerator whiteFlash()
        {
            Debug.Log("HURT");

            Debug.Log(defaultColor);
            StartCoroutine(base.flash(Color.white, 0.5f));
            updateColor();
            resetColor();
            Debug.Log(defaultColor);
            yield return null;
        }
        */

    public void updateColor()
    {
        defaultColor += new Color(RGB_Red_to_White, RGB_Green_to_White, RGB_Blue_to_White, opacityDecrementer);
    }
}