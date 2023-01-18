using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class COLOR : MAIN_GAME_OBJECT_SCRIPT, I_COLOR
{
    // UNITY FIELD OBJECTS
    [SerializeField] internal float flashTime;
    [SerializeField] internal float timeTheFadeStarted;
    [SerializeField] internal float fadeDuration;
    [SerializeField] internal Color defaultColor;
    [SerializeField] internal Color red;
    [SerializeField] internal Color green;
    [SerializeField] internal Color blue;
    [SerializeField] internal Color black;
    [SerializeField] internal Color white;

    [SerializeField] internal Color color_0; //black
    [SerializeField] internal Color color_1; //blue
    [SerializeField] internal Color color_2; //green
    [SerializeField] internal Color color_3; //green+blue = turquis
    [SerializeField] internal Color color_4; //red
    [SerializeField] internal Color color_5; //red+blue = purple 
    [SerializeField] internal Color color_6; //red+green = brown
    [SerializeField] internal Color color_7; //white


    // SET & CONSTRUCTOR

    public new void set()
    {
        base.set();
        flashTime = CONSTANTS.DEFAULT_FLASH_TIME;
        flashTime = 0.5f;
        fadeDuration = 4.8f;
        //timeTheFadeStarted = Time.time;
        timeTheFadeStarted = Time.deltaTime;
        // just for color reasons
        red = new Color(1, 0, 0, 1);
        green = new Color(0, 1, 0, 1);
        blue = new Color(0, 0, 1, 1);
        black = new Color(0, 0, 0, 1);
        white = new Color(1, 1, 1, 1);
        // for future Color picking
        color_0 = new Color(0, 0, 0, 1);
        color_1 = new Color(0, 0, 1, 1);
        color_2 = new Color(0, 1, 0, 1);
        color_3 = new Color(0, 1, 1, 1);
        color_4 = new Color(1, 0, 0, 1);
        color_5 = new Color(1, 0, 1, 1);
        color_6 = new Color(1, 1, 0, 1);
        color_7 = new Color(1, 1, 1, 1);

    }
    public void resetColor()
    {
        spriterender.color = defaultColor;
    }



    public IEnumerator flash(Color colorChange)
    {
        Color originalColor = spriterender.color;
        spriterender.color = colorChange;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        spriterender.color = originalColor;
        yield return null;
    }

    public IEnumerator flash(Color colorChange, float flashTime)
    {
        Color originalColor = spriterender.color;
        spriterender.color = colorChange;
        yield return new WaitForSeconds(flashTime);
        spriterender.color = originalColor;
        yield return null;
    }

    public IEnumerator flashing(Color colorChange, int cycles)
    {
        for (int i = 0; i < cycles; i++)
            flash(colorChange);
        yield return null;
    }

    public IEnumerator flashing(Color colorChange, int cycles, float flashTime)
    {
        for (int i = 0; i < cycles; i++)
            flash(colorChange, flashTime);
        yield return null;
    }





    // functions to be looped
    public void FadingBackGround(Color color1, Color color2)
    {
        var t = Mathf.PingPong(Time.deltaTime, 3.0F) / 3.0F;
        //t = Mathf.PingPong(Time.time, 3.0F) / 3.0F;
        Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
    }

    public void transitionBackGround(Color color1, Color color2)
    {
        Camera.main.backgroundColor = Color.Lerp(color1, color2, (Time.deltaTime - timeTheFadeStarted) / fadeDuration);
    }


    public IEnumerator death_Restart_flashing()
    {
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }

    public IEnumerator Restart()
    {
        Color wall_color = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
        Color player_color = new Color(0.4588f, 0.8198f, 0.6941f, 1);
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = wall_color;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = player_color;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.white;
        yield return new WaitForSeconds(CONSTANTS.DEFAULT_FLASH_TIME);
        Camera.main.backgroundColor = Color.black;
        yield return null;
    }

}

