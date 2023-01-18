using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MAIN_GAME_OBJECT_SCRIPT : MonoBehaviour
{
    // UNITY FIELD OBJECTS
    [SerializeField] internal Animator animator; // affects the pl animation (still to run to jump and so on)
    [SerializeField] internal Rigidbody2D rb2d;  // deals with movement, vectors
    [SerializeField] internal SpriteRenderer spriterender; // graphical part, flips sprite if need be



    // SET & CONSTRUCTOR 
    public void set()
    {
        this.animator = GetComponent<Animator>();
        this.rb2d = GetComponent<Rigidbody2D>();
        this.spriterender = GetComponent<SpriteRenderer>();
    }

}
