using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int PlasticJunkNumber = 0, AluminumJunkNumber = 0, GlassJunkNumber = 0, PaperJunkNumber = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Junk>())
        {
            switch (collider.GetComponent<Junk>().type)
            {
                case Junk.Type.Aluminum:
                    AluminumJunkNumber++;
                    break;
                case Junk.Type.Glass:
                    GlassJunkNumber++;
                    break;
                case Junk.Type.Paper:
                    PaperJunkNumber++;
                    break;
                case Junk.Type.Plastic:
                    PlasticJunkNumber++;
                    break;
            }
        }
    }
}
