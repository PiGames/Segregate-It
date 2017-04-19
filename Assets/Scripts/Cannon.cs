using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;

    public enum shoot_direction_t
    {
        RIGHT,
        LEFT
    }

    public enum rotation_direction_t
    {
        RIGHT = -1,
        LEFT = 1
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

    public shoot_direction_t shootDir;
 
    public int power;
    public float timeRotation;

    private Limits limits;
    private int ankle;

    private float angularVelocity = new float();
    private int alternate = new int();
    private float desiredRot = new float();
    private rotation_direction_t rotatingDir;

    // Use this for initialization
    void Start ()
    {
        this.limits = new Limits(30, 60);
        GameManager.getInstance().cannons.Add(this);
        ankle = Random.Range(limits.down, limits.top + 1);

        if(timeRotation>GameManager.getInstance().interval)
        {
            timeRotation = GameManager.getInstance().interval;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponentInChildren<Transform>().rotation = 
        //Quaternion.LookRotation(Vector3.RotateTowards(gameObject.GetComponent<Transform>().rotation.eulerAngles, new Vector3(0, 0, ankle), angularVelocity, 0X0F));
        //gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);

        var spriteTransform = GetComponentInChildren<Transform>();

        desiredRot += angularVelocity * Time.deltaTime * (int)rotatingDir;
        

        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);


        spriteTransform.rotation = Quaternion.Euler(spriteTransform.eulerAngles.x, spriteTransform.eulerAngles.y, desiredRot);
    }


    public void Shoot()
    {
        //Current object
        GameObject newTrash = Instantiate(prefab, gameObject.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        GameManager.getInstance().trash.Add(newTrash.GetComponent<Junk>());
        alternate = shootDir == shoot_direction_t.RIGHT ? 1 : -1;
        newTrash.GetComponent<Junk>().setParameters(gameObject.GetComponent<Rigidbody2D>().position, new Vector2(alternate * power * Mathf.Cos(Mathf.Deg2Rad * ankle), power * Mathf.Sin(Mathf.Deg2Rad * ankle)));

        //Next object
        var spriteTransform = GetComponentInChildren<Transform>();

        ankle = Random.Range(limits.down,limits.top+1);
        rotatingDir = ankle > spriteTransform.rotation.eulerAngles.z ? rotation_direction_t.LEFT : rotation_direction_t.RIGHT;
        angularVelocity = Mathf.Deg2Rad*Quaternion.Angle(new Quaternion(0, ankle,0,0),gameObject.GetComponent<Transform>().rotation) / timeRotation;

        Debug.LogWarning("angular set " + Quaternion.Angle(new Quaternion(0, 0, ankle, 0), gameObject.GetComponent<Transform>().rotation).ToString());

        alternate = gameObject.GetComponent<Rigidbody2D>().rotation > ankle ? -1 : 1;
     }
}
