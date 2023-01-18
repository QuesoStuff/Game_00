using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_COLLISION 
{
    void collisionWith_Player<T>(T col);
    void collisionWith_Enemy<T>(T col);
    void collisionWith_Self<T>(T col);
    void collisionWith_Other<T>(T col);
    void collsionWith_Item<T>(T col);
    void collisionWith_Wall<T>(T col);

}
