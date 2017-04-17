using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject prefab;
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
    public int power;

    private Limits limits;

	// Use this for initialization
	void Start ()
    {
        this.limits = new Limits(30, 60);
        GameManager.getInstance().cannons.Add(this);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot()
    {
        int ankle = Random.Range(limits.down,limits.top+1);

        GameObject newTrash = Instantiate(prefab, gameObject.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        GameManager.getInstance().trash.Add(newTrash.GetComponent<Junk>());

        int alternate = direction == direction_t.RIGHT ? 1 : -1;

        newTrash.GetComponent<Junk>().setParameters(gameObject.GetComponent<Rigidbody2D>().position, new Vector2(alternate * power * Mathf.Cos(Mathf.Deg2Rad*ankle), power * Mathf.Sin(Mathf.Deg2Rad * ankle)));
    }
}
