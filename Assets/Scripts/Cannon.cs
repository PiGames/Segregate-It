using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public List<GameObject> TrashPrefabs;

    public enum shoot_direction_t
    {
        RIGHT,
        LEFT
    }

    private struct limit_t
    {
        public int down;
        public int top;

        public limit_t(int limitDown, int limitTop)
        {
            this.down = limitDown;
            this.top = limitTop;
        }
    }

    public shoot_direction_t shootDir;
 
    public int power;

    private limit_t limits;
    private Quaternion targetAnkle;

    private float angularVelocity = new float();
    private int alternate = new int();

    // Use this for initialization
    void Start()
    {
        this.limits = new limit_t(30, 60);
        GameManager.getInstance().cannons.Add(this);
        targetAnkle = new Quaternion(0, 0, Random.Range(limits.down, limits.top + 1), 0);
        prepareNextJunk();
    }
    // Update is called once per frame
    void Update()
    {
        //var spriteTransform = GetComponentInChildren<Transform>();
        //spriteTransform.rotation = Quaternion.Lerp(GetComponentInChildren<Transform>().rotation, targetAnkle , Time.time * angularVelocity);
    }

    public void Shoot()
    {
        //Current object
        shootCurrentJunk();
        //Next object
        Invoke("prepareNextJunk", 1);
    }

    private void shootCurrentJunk()
    {
        GameObject newTrash = Instantiate(TrashPrefabs[Random.Range(0,TrashPrefabs.Count)], gameObject.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
        GameManager.getInstance().trash.Add(newTrash.GetComponent<Junk>());
        alternate = 1;//shootDir == shoot_direction_t.RIGHT ? 1 : -1;
        newTrash.GetComponent<Junk>().setParameters(gameObject.GetComponent<Rigidbody2D>().position, new Vector2(alternate * power * Mathf.Cos(Mathf.Deg2Rad * targetAnkle.z), power * Mathf.Sin(Mathf.Deg2Rad * targetAnkle.z)));
        
    }

    private void prepareNextJunk()
    {
        //var spriteTransform = GetComponentInChildren<Transform>();

        targetAnkle = new Quaternion(0, 0, Random.Range(limits.down, limits.top + 1), 0);

        if (shootDir == shoot_direction_t.LEFT)
            targetAnkle.z += 90;

        //Debug.LogWarning("rotacja bazowa: " + spriteTransform.rotation);
        //angularVelocity = Quaternion.Angle(spriteTransform.rotation, targetAnkle) / GameManager.getInstance().interval;
        Debug.LogWarning("angular set " + Quaternion.Angle(targetAnkle, gameObject.GetComponentInChildren<Transform>().rotation).ToString());
        Debug.LogWarning("targetAngle set " + targetAnkle.z);
        Debug.LogWarning("angularVelocity set " + angularVelocity);
        transform.eulerAngles = new Vector3(0f, 0f, targetAnkle.z);
    }
}
