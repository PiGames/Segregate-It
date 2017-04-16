﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Cannon> cannons = new List<Cannon>();
    public List<Trash> trashes = new List<Trash>();

    private Stopwatch timer = new Stopwatch();

    public int interval;

    //Singleton
    public static GameManager getInstance()
    {
        if (instance == null)
        {
            UnityEngine.Debug.LogWarning("You need firstly add instance to scene!");
            return null;
        }
        else return instance;
    }


    // Use this for initialization
    void Awake ()
    {
        UnityEngine.Debug.LogWarning("awake");

        //Code checking if exist only one instance of class
        if (instance != null) Destroy(this);
        else instance = this;
        //

        timer.Start();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(timer.Elapsed.Seconds>interval)
        {
            foreach(var cannon in cannons)
            {
                cannon.Shoot();
            }

            timer.Reset();
            timer.Start();
        }
	}
}
