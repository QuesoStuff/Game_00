using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRenderScript : MonoBehaviour

{
    [SerializeField] internal SpriteRenderer spriterender; // graphical part, flips sprite if need be
    public void set()
    {
        this.spriterender = gameObject.GetComponent<SpriteRenderer>();
        spriterender.enabled = false;
    }
    public void Start()
    {
        set();
    }
}