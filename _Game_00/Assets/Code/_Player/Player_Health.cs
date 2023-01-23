
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : HEALTH
{

    // ADDED SCRIPTS (internal allows to be accessed)
    [SerializeField] internal _Player_Script mainScript;

    // FIELDS (Unity types)

    // FIELDS (variables)
    [SerializeField] internal int HP_Total_Damage;
    [SerializeField] internal int HP_Total_Heal;


    //[SerializeField] internal int HP_Total_Damage;
    //[SerializeField] internal int HP_Total_Heal;
    // SET and CONSTRUCTORS 

    void setComponent()
    {
        //mainScript = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<_Player_Script>();
        mainScript = GetComponent<_Player_Script>();
    }
    public new void set()
    {
        setComponent();
        base.set();
        HP_Total_Damage = HP_Total_Heal = 0;
        //UI
        HP_Display.currHP = HP;
        HP_Display.maxHP = HP_Max;
    }


    // GETTERS AND SETTERS


    // I_Parent_Interface METHOD DECLARATION (most likely Abstract)
    //I_HP_Damage,
    public override void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
        {
            HP_Total_Damage += HP;
            HP_Zero();
        }
        else
            HP_Total_Damage += CONSTANTS.HP_DEFAULT_DAMAGE;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    public override void HP_damage(int HP_damage)
    {
        HP -= HP_damage;
        if (HP <= 0)
        {
            HP_Total_Damage += HP;
            HP_Zero();
        }
        else
            HP_Total_Damage += HP_damage;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    //I_HP_Heal,
    public override void HP_heal()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        if (HP > HP_Max)
        {
            HP_Total_Heal += HP_Max - CONSTANTS.HP_DEFAULT_HEALTH;
            HP = HP_Max;
        }
        else
            HP_Total_Heal += CONSTANTS.HP_DEFAULT_HEALTH;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    public override void HP_heal(int HP_heal)
    {
        HP += HP_heal;
        if (HP > HP_Max)
        {
            HP_Total_Heal += HP_Max - HP_heal;
            HP = HP_Max;
        }
        else
            HP_Total_Heal += HP_heal;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    //I_HP_Full_Restore,
    public override void HP_fullRestore()
    {
        HP_Total_Heal += HP_Max - HP;
        HP = HP_Max;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    //I_HP_Heal_Unbounded,
    public override void HP_heal_unbounded()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        HP_Total_Heal += CONSTANTS.HP_DEFAULT_HEALTH;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    public override void HP_heal_unbounded(int HP_heal)
    {
        HP += HP_Heal;
        HP_Total_Heal += HP_Heal;
        //UI
        HP_Display.currHP = HP;
        //HP_Display.maxHP = HP_Max;
    }
    //I_HP_Increase_Max_Health
    public override void HP_increaseMaxHealth()
    {
        HP_Max += CONSTANTS.HP_DEFAULT_MAX_HP_INCREASE;
        //UI
        //HP_Display.currHP = HP;
        HP_Display.maxHP = HP_Max;
    }

    public override void HP_increaseMaxHealth(int HP_Extra)
    {
        HP_Max += HP_Extra;
        //UI
        //HP_Display.currHP = HP;
        HP_Display.maxHP = HP_Max;
    }

    // I_other_Interface METHOD DECLARATION (may not exist)
    public override void HP_Zero()
    {
        // TRIGGER END
        StartCoroutine(Level_Controller_Simple.death_Restart());

    }

}