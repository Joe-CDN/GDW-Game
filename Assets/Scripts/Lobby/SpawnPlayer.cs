using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.InteropServices;
using System.IO;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;

    public Vector2 minRange;
    public Vector2 maxRange;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(Application.dataPath + "/position.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/position.txt");
            Debug.Log(saveString);

            for (int i = 1; i < saveString.Length; i++)
            {
                string[] array = saveString.Split(',');

                pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));

                Debug.Log(pos);
            }

            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        //Vector3 random = transform.position + Vector3.right * Random.Range(minRange.x, maxRange.x) + Vector3.forward * Random.Range(minRange.y, maxRange.y);
        GameObject test = PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.identity);
        if (test.GetComponent<PhotonView>().IsMine) {
            test.GetComponent<OnlineMove>().SetData(Instantiate(cameraPrefab, transform.position, Quaternion.Euler(40f, 0f, 0f)));
        }
    }
}