using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Cannon> cannons = new List<Cannon>();
    public List<Junk> trash = new List<Junk>();

    private Stopwatch timer = new Stopwatch();

    private int points = new int();

    public GameObject MainMenu;
    public GameObject GameOverMenu;

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
        //Code checking if exist only one instance of class
        if (instance != null) Destroy(this);
        else instance = this;
        //

        points = 0;

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

    public void addPoint()
    {
        points++;
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        MainMenu.SetActive(true);
        GameOverMenu.SetActive(false);
    }
    public void GameStart()
    {
        GameOverMenu.SetActive(false);
        MainMenu.SetActive(false);
    }
}
