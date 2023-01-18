using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level_Controller_Simple : MonoBehaviour
{
    //[SerializeField] internal  Camera cam;

    [SerializeField] internal Color colorBackground;
    [SerializeField] internal Color colorPlayer;
    [SerializeField] internal Color colorWhite;
    [SerializeField] internal Color colorBlack;
    [SerializeField] internal Color colorWall;

    // Use this for initialization
    public void set()
    {
        colorWall = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
        colorPlayer = new Color(0.4588f, 0.8198f, 0.6941f, 1);
        colorBackground = new Color(0.238392f, 0.2047437f, 0.4056604f, 0);
        colorWhite = Color.white;
        colorBlack = Color.black;
    }
    public void Start()
    {
        set();
    }

    // Update is called once per frame
    public void Update()
    {

    }
    public IEnumerator Restart()
    {
        ColorWall();
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorPlayer();
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorBack();
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorWall();
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator death_Restart()
    {
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorBlack();
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorBlack();
        yield return new WaitForSeconds(0.25f);
        ColorWhite();
        yield return new WaitForSeconds(0.25f);
        ColorWall();
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ColorBlack()
    {
        Camera.main.backgroundColor = colorBlack;
    }
    public void ColorWhite()
    {
        Camera.main.backgroundColor = colorWhite;
    }
    public void ColorPlayer()
    {
        Camera.main.backgroundColor = colorPlayer;
    }
    public void ColorBack()
    {
        Camera.main.backgroundColor = colorBackground;
    }
    public void ColorWall()
    {
        Camera.main.backgroundColor = colorWall;
    }
}