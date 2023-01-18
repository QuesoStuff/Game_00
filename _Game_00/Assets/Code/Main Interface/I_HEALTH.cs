using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_HEALTH 
{
    void HP_damage();
    void HP_damage(int HP_damage);
    void HP_heal();
    void HP_heal(int HP_heal);
    void HP_heal_unbounded();
    void HP_heal_unbounded(int HP_heal);
    void HP_fullRestore();
    void HP_increaseMaxHealth();
    void HP_increaseMaxHealth(int HP_Extra);
    void HP_Zero();

}
