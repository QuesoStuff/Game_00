using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Color : COLOR
{
    [SerializeField] internal _Player_Script mainScript;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_HURT;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_DASH;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_COLLISION;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_HP_UP;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_BIG_SHOOT;
    [SerializeField] internal Color DEFAULT_PLAYER_COLOR_BIG_SHOOT_READY;

    void setComponent()
    {
        //mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        mainScript = GetComponent<_Player_Script>();

    }
    public new void set()
    {
        base.set();
        setComponent();
        defaultColor = new Color(0.4588f, 0.8198f, 0.6941f, 1);
        DEFAULT_PLAYER_COLOR = defaultColor;
        DEFAULT_PLAYER_COLOR_HURT = new Color32(128, 255, 128, 255);
        DEFAULT_PLAYER_COLOR_DASH = new Color32(16, 178, 165, 255);
        DEFAULT_PLAYER_COLOR_COLLISION = Color.white;
        DEFAULT_PLAYER_COLOR_HP_UP = new Color32(16, 178, 107, 255);
        DEFAULT_PLAYER_COLOR_BIG_SHOOT = new Color32(178, 16, 20, 255);
        DEFAULT_PLAYER_COLOR_BIG_SHOOT_READY = new Color32(100, 16, 20, 255);

        resetColor();
    }

    public IEnumerator HP_up()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_HP_UP));
        yield return null;
    }
    public IEnumerator hurt()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_HURT));
        yield return null;
    }
    public IEnumerator dash()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_DASH, mainScript.Controller.dashingTime));
        yield return null;
    }
    public IEnumerator shoot()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_BIG_SHOOT, mainScript.Controller.dashingTime));
        yield return null;
    }
    public IEnumerator chargeShootReady()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_BIG_SHOOT_READY, mainScript.Controller.dashingTime));
        yield return null;
    }
    public IEnumerator wall_collision()
    {
        StartCoroutine(base.flash(DEFAULT_PLAYER_COLOR_COLLISION));
        yield return null;
    }

}