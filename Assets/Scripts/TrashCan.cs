using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int JunkNumber = 0;
    public Junk.Type TrashCanType;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Junk>().type != TrashCanType)
        {
            GameManager.getInstance().GameOver();
        }
        else
        {
            JunkNumber++;
        }

        Destroy(collider.gameObject);

    }
}
