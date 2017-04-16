using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Trash(Vector2 initialPosition, Vector2 initialVelocity)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = initialVelocity;
        gameObject.GetComponent<Rigidbody2D>().position = initialPosition;
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
