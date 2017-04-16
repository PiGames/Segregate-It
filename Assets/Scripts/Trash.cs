using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Trash : MonoBehaviour
{
    public enum Type
    {
        Paper,
        Plastic,
        Aluminum,
        Glass
    }

    public Type type;
    // Use this for initialization
    void Start ()
    {	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void setParameters(Vector2 initialPosition, Vector2 initialVelocity)
    {
        GetComponentInParent<Rigidbody2D>().velocity = initialVelocity;
        GetComponentInParent<Rigidbody2D>().position = initialPosition;
    }
}
