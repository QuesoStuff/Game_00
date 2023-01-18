using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] internal float followSpeed = 2f;
    [SerializeField] internal float y_Offset = 1f;
    [SerializeField] internal float z_CamValue = -10f;

    [SerializeField] internal Transform target;
    [SerializeField] internal bool transition;
    [SerializeField] internal float t;
    [SerializeField] internal float fadeDuration;
    [SerializeField] internal float timeTheFadeStarted;
    [SerializeField] internal int ZOOM;

    [SerializeField] internal Color Color1;
    [SerializeField] internal Color Color2;




    public void setComponent()
    {
        target = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<Transform>();
    }
    public void set()
    {
        setComponent();
        fadeDuration = 4.8f;
        //timeTheFadeStarted = Time.time;
        timeTheFadeStarted = Time.time ;
        Color1 = new Color(0.9339623f, 0.5850481f, 0.5850481f, 1); //wall
        Color2 = new Color(0.238392f, 0.2047437f, 0.4056604f, 0); //background
        ZOOM = 6;
    }
    // Update is called once per frame
    public void flashingBackGround()
    {
        //t = Mathf.PingPong(Time.time, 3.0F) / 3.0F;
        t = Mathf.PingPong(Time.deltaTime, 3.0F) / 3.0F;
        Camera.main.backgroundColor = Color.Lerp(Color1, Color2, t);
    }
    public void Awake()
    {

    }
    public void Start()
    {
        set();
        ColorWall();
    }
    public void Update()
    {
                Camera.main.orthographicSize  = ZOOM;
        Vector3 playerPosition = new Vector3(target.position.x, target.position.y + y_Offset, z_CamValue);
        transform.position = Vector3.Slerp(transform.position, playerPosition, followSpeed * Time.deltaTime);
        //Camera.main.backgroundColor = Color.Lerp(Color1, Color2, (Time.time) / fadeDuration);
        if (fadeDuration > Time.deltaTime)
        {
            Camera.main.backgroundColor = Color.Lerp( Camera.main.backgroundColor, Color2, Time.deltaTime / fadeDuration);
            fadeDuration -= Time.deltaTime;
        }
 

    }

    public void ColorWall()
    {
        Camera.main.backgroundColor = Color1;
    }
    public void transitionColor(Color newColor)
    {
        //Color1 = Color2;
        //Color2 = newColor;
        Color1 = Camera.main.backgroundColor;
        Color2 = newColor;
        fadeDuration = 4.8f;
    }

}






