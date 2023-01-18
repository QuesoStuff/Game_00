
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HEALTH : MonoBehaviour, I_HEALTH //, I_other_Interface
{

    // ADDED SCRIPTS (internal allows to be accessed)
 
    // FIELDS (Unity types)

    // FIELDS (variables)
    [SerializeField] internal int HP_Max;
    [SerializeField] internal int HP;
    [SerializeField] internal int HP_Damage;
    [SerializeField] internal int HP_Heal;


    //[SerializeField] internal int HP_Total_Damage;
    //[SerializeField] internal int HP_Total_Heal;
    // SET and CONSTRUCTORS 
    public void set()
    {

        this.HP = CONSTANTS.HP_DEFAULT_STARTER_HP;
        this.HP_Max = this.HP;
        this.HP_Damage = CONSTANTS.HP_DEFAULT_DAMAGE;
        this.HP_Heal = CONSTANTS.HP_DEFAULT_HEALTH;
    }


    // GETTERS AND SETTERS


    // I_Parent_Interface METHOD DECLARATION (most likely Abstract)
    //I_HP_Damage,
    public virtual void HP_damage()
    {
        HP -= CONSTANTS.HP_DEFAULT_DAMAGE;
        if (HP <= 0)
        HP_Zero();
    }
    public virtual void HP_damage(int HP_damage)
    {
        HP -= HP_Damage;
        if (HP <= 0)
        HP_Zero();
    }
    //I_HP_Heal,
    public virtual void HP_heal()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
        if (HP > HP_Max)
        HP = HP_Max;
    }
    public virtual void HP_heal(int HP_heal)
    {
        HP += HP_Heal;
        if (HP > HP_Max)
        HP = HP_Max;
    }
    //I_HP_Full_Restore,
    public virtual void HP_fullRestore()
    {
        HP = HP_Max;
    }
    //I_HP_Heal_Unbounded,
    public virtual void HP_heal_unbounded()
    {
        HP += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public virtual void HP_heal_unbounded(int HP_heal)
    {
        HP += HP_Heal;
    }
    //I_HP_Increase_Max_Health
    public virtual void HP_increaseMaxHealth()
    {
        HP_Max += CONSTANTS.HP_DEFAULT_HEALTH;
    }
    public virtual void HP_increaseMaxHealth(int HP_Extra)
    {
        HP_Max += HP_Extra;
    }
    // I_other_Interface METHOD DECLARATION (may not exist)
    public virtual void HP_Zero()
    {
        Destroy(gameObject);
    }


}