using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager instance { get; private set; }
    public AudioClip dropInCauldron;

    public int score;

    public float dayDelay = 10f;
    public float lastDayTime;

    public bool useJoystick = false;
    public bool grabObject = false;

    public Text scoreLabel;
    public Text clock;

    private bool playing;
    private int dayTime;

    private void Awake()
    {
        dayTime = 6;
        playing = true;
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Time.time - lastDayTime > dayDelay && playing == true){
            dayTime++;
            lastDayTime = Time.time;
        }

        if(dayTime < 12){
            clock.text = " " + dayTime + "am";
        }
        if(dayTime == 12){
            clock.text = " " + dayTime + "pm";
        }
        if(dayTime > 12){
            clock.text = " " + (dayTime - 12) + "pm";
        }
        if(dayTime > 24){
            dayTime = 6;
        }  
        scoreLabel.text = "Money: " + score + "gp";
    }
}
