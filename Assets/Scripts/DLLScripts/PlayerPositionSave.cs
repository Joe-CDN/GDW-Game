using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class PlayerPositionSave : MonoBehaviour
{
    [DllImport("StateSaver")]
    static extern Vector3 getPos();

    [DllImport("StateSaver")]
    static extern void setPos(float x,float y, float z);

    [DllImport("StateSaver")]
    static extern void savePos();

    Vector3 position;
    // Update is called once per frame

    private void OnApplicationQuit()
    {
        PositionSave();
    }
    public void PositionSave()
    {
        Vector3 pos = transform.position;
        setPos(pos.x, pos.y, pos.z);
        savePos();
    }
}
