using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseSpawn : MonoBehaviour
{
    [SerializeField]    private GameObject Prefab;

    public static roseSpawn Instance {get; private set;}

    private void Awake(){
        Instance = this;
        //GrowPool();
    }
    void Start()
    {
        //SpawnFromPool(Prefab);
        PersistanceManager.instance.roses = 0;
    }
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2f && Input.GetKeyDown(KeyCode.E))
        {
            if(PersistanceManager.instance.roses < 1)
            {
                SpawnFromPool(Prefab);
                PersistanceManager.instance.roses += 1;
                Debug.Log(PersistanceManager.instance.roses);
            }            
        }
    }

    public void SpawnFromPool(GameObject prefab){
        var spawn = rosePool.Instance.GetFromPool(prefab);
        spawn.transform.position = this.transform.position;
    }
}
