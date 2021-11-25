using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class ScoreSave : MonoBehaviour
{
    [DllImport("ScoreSaver")]
    static extern int getScore();

    [DllImport("ScoreSaver")]
    static extern void setScore(float s);

    [DllImport("ScoreSaver")]
    static extern Vector3 scoreText();

    private int highScore;
    // Start is called before the first frame update
    void Start()
    {

        if (System.IO.File.Exists(Application.dataPath + "/score.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/score.txt");
            Debug.Log(saveString);
     
            highScore= int.Parse(saveString);
       
        }
        PersistanceManager.instance.score = highScore;
        //Debug.Log(highScore);
    }

    public void setHighScore()
    {
        Debug.Log(highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
