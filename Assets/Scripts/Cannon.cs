using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public List<GameObject> TrashPrefabs;

    public enum shoot_direction_t
    {
        RIGHT,
        LEFT
    }


    public shoot_direction_t shootDir;
    public int power;
    private limit_t limits;
    private Quaternion targetAnkle;
    private float interval = new float();
    private int alternate = new int();
    private Stopwatch timer = new Stopwatch();

    // Use this for initialization
    void Start()
    {
        this.limits = new limit_t(45, 70);

        if (shootDir == shoot_direction_t.LEFT)
        {
            limits -= new limit_t(45, 45);
        }

        GameManager.getInstance().cannons.Add(this);
        targetAnkle = new Quaternion(0, 0, Random.Range(limits.down, limits.top + 1), 0);
        interval = Random.Range(40, 50) / 10f;
        prepareNextJunk();
        Invoke("Shoot", Random.Range(15, 25) / 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        //Current object
        shootCurrentJunk();
        //Next object
        Invoke("prepareNextJunk", 1);

        //prepare timer
        timer.Reset();
        timer.Start();
    }

    private void shootCurrentJunk()
    {
        GameObject newTrash = Instantiate(TrashPrefabs[Random.Range(0,TrashPrefabs.Count)], gameObject.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        GameManager.getInstance().trash.Add(newTrash.GetComponent<Junk>());
        alternate = 1;//shootDir == shoot_direction_t.RIGHT ? 1 : -1;
        newTrash.GetComponent<Junk>().setParameters(gameObject.GetComponent<Rigidbody2D>().position, new Vector2(alternate * power * Mathf.Cos(Mathf.Deg2Rad * targetAnkle.z), power * Mathf.Sin(Mathf.Deg2Rad * targetAnkle.z)));
        newTrash.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f);
    }

    private void prepareNextJunk()
    {

        targetAnkle = new Quaternion(0, 0, Random.Range(limits.down, limits.top + 1), 0);

        if (shootDir == shoot_direction_t.LEFT)
            targetAnkle.z += 90;

        transform.eulerAngles = new Vector3(0f, 0f, targetAnkle.z);
    }

    public void TryShoot()
    {
        if (timer.Elapsed.TotalMilliseconds> interval*1000)
        { 
            this.Shoot();
        }
    }
}
