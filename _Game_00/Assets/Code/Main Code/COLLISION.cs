
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class COLLISION : MAIN_GAME_OBJECT_SCRIPT, I_COLLISION//, I_other_Interface
{

    // ADDED SCRIPTS (internal allows to be accessed)


    //I_Collision_Self
    public virtual void collisionWith_Player<T>(T col) { }
    public virtual void collisionWith_Enemy<T>(T col) { }
    public virtual void collisionWith_Self<T>(T col) { }
    public virtual void collisionWith_Other<T>(T col) { }
    public virtual void collsionWith_Item<T>(T col) { }
    public virtual void collisionWith_Wall<T>(T col) { }


    // I_other_Interface METHOD DECLARATION (may not exist)
    public new void set()
    {
        base.set();
    }
}