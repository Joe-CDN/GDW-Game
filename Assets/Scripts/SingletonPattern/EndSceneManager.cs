using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().clip = PersistanceManager.instance.dayEndMusic;
        GetComponent<AudioSource> ().playOnAwake = true;        
        GetComponent<AudioSource> ().loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Money Earned: " + PersistanceManager.instance.score + "gp";
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("Start");
        GetComponent<AudioSource> ().Stop();
    }
    public void toLobby()
    {
        SceneManager.LoadScene("Load");
        GetComponent<AudioSource> ().Stop();
    }
}
