using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public static AI Instance {get; private set;}
    public GameObject StartPos;
    public GameObject EndPos;
    public GameObject hand;
    public GameObject bubble;
    public ParticleSystem faeBubble;
    public ParticleSystem goldBubble;
    public ParticleSystem happyBubble;
    public ParticleSystem loveBubble;
    public ParticleSystem pureBubble;
    public ParticleSystem sadBubble;
    public ParticleSystem timeBubble;
    public ParticleSystem truthBubble;

    [SerializeField]    private GameObject bloodPrefab;
    
    //bool approach = true;
    int randPotRequest = 0;
    float potionTotalRequested = 0f;
    //float fraction = 0;
    public float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //RequestPotion();
        PersistanceManager.instance.npcApproach = true;
        PersistanceManager.instance.npcApproachPercent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //PersistanceManager.instance.npcApproach = approach;
        //PersistanceManager.instance.npcApproachPercent = fraction;
        if(PersistanceManager.instance.npcApproach == true){
            if (PersistanceManager.instance.npcApproachPercent < 1f) {
                PersistanceManager.instance.npcApproachPercent += Time.deltaTime * speed;

                Vector3 interpolatedPosition = Vector3.Lerp(StartPos.transform.position, EndPos.transform.position, PersistanceManager.instance.npcApproachPercent);

                this.transform.position = interpolatedPosition;
                if (PersistanceManager.instance.npcApproachPercent >= 0.95f)
                {
                    RequestPotion();
                }
                if (PersistanceManager.instance.npcApproachPercent >= 1f && potionTotalRequested == 50.61f) {
                    giveDNA();
                }
            }
        }
        if(PersistanceManager.instance.npcApproach == false){
            if (PersistanceManager.instance.npcApproachPercent < 1f) {
                PersistanceManager.instance.npcApproachPercent += Time.deltaTime * speed;
                
                this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);    
                
                Vector3 interpolatedPosition = Vector3.Lerp(EndPos.transform.position, StartPos.transform.position, PersistanceManager.instance.npcApproachPercent);

                this.transform.position = interpolatedPosition;
                if (PersistanceManager.instance.npcApproachPercent >= 0.95f) {
                    PersistanceManager.instance.npcApproach = true;
                    this.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                    PersistanceManager.instance.npcApproachPercent = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("purePot")){
            if(potionTotalRequested == 27.77f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
                GameSceneManager.NPCMaxTime -= 2f;
            }            
        }
        if (collision.collider.tag.Equals("goldPot")){
            if(potionTotalRequested == 23.26f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
                GameSceneManager.NPCMaxTime -= 2f;
            } 
        }
        if (collision.collider.tag.Equals("sadPot")){
            if(potionTotalRequested == 29.18f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
        if (collision.collider.tag.Equals("lovePot")){
            if(potionTotalRequested == 50.61f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 40;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
        if (collision.collider.tag.Equals("catFaePot")){
            if(potionTotalRequested == 30.21f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 30;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
        if (collision.collider.tag.Equals("timePot")){
            if(potionTotalRequested == 26.19f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
        if (collision.collider.tag.Equals("truthPot")){
            if(potionTotalRequested == 14.88f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 10;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
        if (collision.collider.tag.Equals("happyPot")){
            if(potionTotalRequested == 23.42f){
                ResetNPC(collision);
                PersistanceManager.instance.score += 20;
                GameSceneManager.NPCMaxTime -= 2f;
            }
        }
    }
    void ResetNPC(Collision collision)
    {
        //Destroy(collision.gameObject);
        if (collision.collider.tag.Equals("catFaePot"))
        {
            collision.gameObject.transform.position = GameObject.Find("faeSp").transform.position;
        }
        if (collision.collider.tag.Equals("goldPot"))
        {
            collision.gameObject.transform.position = GameObject.Find("goldSp").transform.position;
        }
        if (collision.collider.tag.Equals("happyPot"))
        {
            collision.gameObject.transform.position = GameObject.Find("hapSp").transform.position;
        }
        if (collision.collider.tag.Equals("lovePot"))
        {
            collision.gameObject.transform.position = GameObject.Find("loveSp").transform.position;
        }
        if (collision.collider.tag.Equals("purePot"))
        {
            collision.gameObject.transform.position = GameObject.Find("pureSp").transform.position;
        }
        if (collision.collider.tag.Equals("sadPot"))
        {
            collision.gameObject.transform.position = GameObject.Find("sadSp").transform.position;
        }
        if (collision.collider.tag.Equals("timePot"))
        {
            collision.gameObject.transform.position = GameObject.Find("timeSp").transform.position;
        }
        if (collision.collider.tag.Equals("truthPot"))
        {
            collision.gameObject.transform.position = GameObject.Find("truthSp").transform.position;
        }
        PersistanceManager.instance.npcApproachPercent = 0;
        PersistanceManager.instance.npcApproach = false;
        pureBubble.gameObject.SetActive(false);
        goldBubble.gameObject.SetActive(false);
        sadBubble.gameObject.SetActive(false);
        loveBubble.gameObject.SetActive(false);
        faeBubble.gameObject.SetActive(false);
        timeBubble.gameObject.SetActive(false);
        truthBubble.gameObject.SetActive(false);
        happyBubble.gameObject.SetActive(false);
    }
    void RequestPotion()
    {
        randPotRequest = Random.Range(0, 8);

        if(randPotRequest == 0){
            potionTotalRequested = 27.77f; //purify potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.6509434f, 0.6349769f, 0.6349769f);
            pureBubble.gameObject.SetActive(true);

            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 1){
            potionTotalRequested = 23.26f; //gold potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0.8382407f, 0f);
            goldBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 2){
            potionTotalRequested = 29.18f; //sad potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0.1437f, 0.01331432f, 0.4150943f);
            sadBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 3){
            potionTotalRequested = 50.61f; // love potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0f, 0.9095554f);
            loveBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 4){
            potionTotalRequested = 30.21f; //cat fairy potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 1f, 0.7181935f);
            faeBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 5){
            potionTotalRequested = 26.19f; //time potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 0.4150943f, 0.05119479f);
            timeBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 6){
            potionTotalRequested = 14.88f; //truth potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(0f, 0.5359084f, 1f);
            truthBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            happyBubble.gameObject.SetActive(false);
        }
        if(randPotRequest == 7){
            potionTotalRequested = 23.42f; //happy potion
            //bubble.GetComponentInChildren<MeshRenderer>().material.color = new Color(1f, 0.4665077f, 0f);
            happyBubble.gameObject.SetActive(true);

            pureBubble.gameObject.SetActive(false);
            goldBubble.gameObject.SetActive(false);
            sadBubble.gameObject.SetActive(false);
            loveBubble.gameObject.SetActive(false);
            faeBubble.gameObject.SetActive(false);
            timeBubble.gameObject.SetActive(false);
            truthBubble.gameObject.SetActive(false);
        }

        //Debug.Log("potion requested" + potionTotalRequested);
    }

    void giveDNA()
    {
        //SpawnFromPool(bloodPrefab);
        bloodPrefab.transform.position = hand.transform.position;
    }
    public void SpawnFromPool(GameObject prefab){
        var spawn = dnaPool.Instance.GetFromPool(prefab);
        spawn.transform.position = hand.transform.position;
    }
}
