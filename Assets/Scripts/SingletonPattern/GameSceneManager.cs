using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.IO;
public class GameSceneManager : MonoBehaviour
{
    public float dayDelay = 10f;
    public float lastDayTime;
    private int dayTime;
    public float NPCMaxTime = 60;

    public Text scoreLabel;
    public Text clock;

    public Text npcTimer;

    private void Awake()
    {
        if (System.IO.File.Exists(Application.dataPath + "/time.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/time.txt");
            Debug.Log(saveString);

            dayTime = int.Parse(saveString);

        }
        PersistanceManager.instance.countDown = NPCMaxTime;
        PersistanceManager.instance.playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        PersistanceManager.instance.timeOfDay = dayTime;

        if(Time.time - lastDayTime > dayDelay && PersistanceManager.instance.playing == true){
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

        scoreLabel.text = "Money: " + PersistanceManager.instance.score + "gp";
        
        if(PersistanceManager.instance.npcApproach && PersistanceManager.instance.npcApproachPercent >= 1)
        {            
            DisplayTime(PersistanceManager.instance.countDown);
            if(PersistanceManager.instance.countDown > 0)
            {
                PersistanceManager.instance.countDown -= Time.deltaTime;
            }
            else
            {
                PersistanceManager.instance.countDown = 0;
            }
        }
        else
        {
            npcTimer.text = " ";
            PersistanceManager.instance.countDown = NPCMaxTime;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
            timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        npcTimer.text = "Patience (" + minutes + ":" + seconds + ") ";
    }
}
