using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;

public class TimeSave : MonoBehaviour
{
    [DllImport("StateSaver")]
    static extern Vector3 getTime();

    [DllImport("StateSaver")]
    static extern void setTime(float s);

    [DllImport("StateSaver")]
    static extern void saveTime();

    private int time;
    private void Start()
    {
    }
    void Update()
    {
        TimeSaver();
    }

    public void TimeSaver()
    {
        setTime(PersistanceManager.instance.timeOfDay);
        saveTime();
    }

}
