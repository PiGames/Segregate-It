using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Trash(Vector2 InitialVelocity)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = InitialVelocity;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
