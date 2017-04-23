using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Junk : MonoBehaviour
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

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        GetComponentInParent<Rigidbody2D>().velocity = Vector3.zero;
    }


    public void setParameters(Vector2 initialPosition, Vector2 initialVelocity)
    {
        GetComponentInParent<Rigidbody2D>().velocity = initialVelocity;
        GetComponentInParent<Rigidbody2D>().position = initialPosition;
    }
}
