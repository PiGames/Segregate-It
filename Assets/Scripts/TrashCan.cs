using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int PlasticJunkNumber = 0, AluminumJunkNumber = 0, GlassJunkNumber = 0, PaperJunkNumber = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Trash>())
        {
            switch (collider.GetComponent<Trash>().type)
            {
                case Trash.Type.Aluminum:
                    AluminumJunkNumber++;
                    break;
                case Trash.Type.Glass:
                    GlassJunkNumber++;
                    break;
                case Trash.Type.Paper:
                    PaperJunkNumber++;
                    break;
                case Trash.Type.Plastic:
                    PlasticJunkNumber++;
                    break;
            }
        }
    }
}
