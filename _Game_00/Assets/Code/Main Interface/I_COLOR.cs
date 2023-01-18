
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_COLOR 
{
        IEnumerator flash(Color colorChange);
    IEnumerator flash(Color colorChange , float flashTime);
    IEnumerator flashing(Color colorChange , int cycles);
    IEnumerator flashing(Color colorChange , int cycles, float flashTime);
    //IEnumerator flash(Color colorChange1 ,Color ColorChange2);
    //IEnumerator flash(Color colorChange1 ,Color ColorChange2 , float flashTime);


    void FadingBackGround(Color color1 , Color color2);
    void transitionBackGround(Color color1 , Color color2);
    IEnumerator death_Restart_flashing();
    IEnumerator Restart();

     void resetColor();

}
