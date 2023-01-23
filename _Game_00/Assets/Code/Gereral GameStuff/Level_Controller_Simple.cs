using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static class Level_Controller_Simple 
{
    //[SerializeField] internal  Camera cam;

    [SerializeField] internal static  Color colorBackground;
    [SerializeField] internal static  Color colorPlayer;
    [SerializeField] internal static  Color colorWhite;
    [SerializeField] internal static  Color colorBlack;
    [SerializeField] internal static  Color colorWall;

    // Use this for initialization
    public static void set()
    {
        colorWall = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1);
        colorPlayer = new Color(0.4588f, 0.8198f, 0.6941f, 1);
        colorBackground = new Color(0.238392f, 0.2047437f, 0.4056604f, 0);
        colorWhite = Color.white;
        colorBlack = Color.black;
    }

    public static IEnumerator timer_end_Restart()
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
        SaveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static IEnumerator death_Restart()
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
        SaveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void ColorBlack()
    {
        Camera.main.backgroundColor = colorBlack;
    }
    public static void ColorWhite()
    {
        Camera.main.backgroundColor = colorWhite;
    }
    public static void ColorPlayer()
    {
        Camera.main.backgroundColor = colorPlayer;
    }
    public static void ColorBack()
    {
        Camera.main.backgroundColor = colorBackground;
    }
    public static void ColorWall()
    {
        Camera.main.backgroundColor = colorWall;
    }
}