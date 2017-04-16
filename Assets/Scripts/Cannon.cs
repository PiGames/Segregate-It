using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public enum direction_t
    {
        RIGHT,
        LEFT
    }

    private struct Limits
    {
        public int down;
        public int top;

        public Limits(int limitDown, int limitTop)
        {
            this.down = limitDown;
            this.top = limitTop;
        }
    }

    public direction_t direction;

    private Limits limits;

	// Use this for initialization
	void Start ()
    {
        this.limits = new Limits(30, 60);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot()
    {
        int ankle = Random.Range(limits.down,limits.top+1);
    }
}
