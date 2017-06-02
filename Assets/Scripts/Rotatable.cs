using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{

    public float rotateX;
    public float rotateY;
    public float rotateZ;

    private Transform parentTransform;
    private Vector3 rotateVec;

    // Use this for initialization
    void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
        rotateVec = new Vector3(rotateX, rotateY, Mathf.Pow(-1,Random.Range(1,2))*rotateZ-Random.Range(0,2));
    }

    // Update is called once per frame
    void Update()
    {
        parentTransform.Rotate(rotateVec);
    }
}
