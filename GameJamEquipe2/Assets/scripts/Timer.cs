﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Survivaltime = 0;
    public int seconds = 0;
    public int minutes = 0;
    float timeRise = 0;

    
    public Text TimeText;
    public bool playerIsAlive = true;
    GameObject spawnerManagerObject;
    private SpawnerManager spawnerManager;
  


    // Start is called before the first frame update
    void Start()
    {
        if (spawnerManagerObject == null)
        {
            spawnerManagerObject = GameObject.FindWithTag("Spawner");
            spawnerManager = spawnerManagerObject.GetComponent<SpawnerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)Survivaltime / 60;
        seconds = (int)Survivaltime % 60;

        if (playerIsAlive)
        {
            Survivaltime += Time.deltaTime; 
        }
        else
        {
            PlayerPrefs.SetInt("minutes", minutes);
            PlayerPrefs.SetInt("seconds", seconds);
        }

        TimeText.text = "Time : " + minutes + " : " + seconds;


        if(minutes == timeRise + 1)
        {
            timeRise++;
            spawnerManager.raiseTimeSpawn();
        }
    }

    public float getTime()
    {
        return Survivaltime;
    }
}
