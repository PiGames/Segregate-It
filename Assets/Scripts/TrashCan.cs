using System;
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
            updateUI();
        }

        Destroy(collider.gameObject);

    }

    private void updateUI()
    {
        switch (TrashCanType)
        {
            case Junk.Type.Aluminum:
                {
                    var textComponent = GameObject.FindGameObjectWithTag("AluminumUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text;

                    GameObject.FindGameObjectWithTag("AluminumUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text = (Int32.Parse(textComponent) + 1).ToString();

                    break;
                }

            case Junk.Type.Glass:
                {
                    var textComponent = GameObject.FindGameObjectWithTag("GlassUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text;

                    GameObject.FindGameObjectWithTag("GlassUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text = (Int32.Parse(textComponent) + 1).ToString();

                    break;
                }

            case Junk.Type.Paper:
                {
                    var textComponent = GameObject.FindGameObjectWithTag("PaperUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text;

                    GameObject.FindGameObjectWithTag("PaperUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text = (Int32.Parse(textComponent) + 1).ToString();

                    break;
                }
            case Junk.Type.Plastic:
                {
                    var textComponent = GameObject.FindGameObjectWithTag("PlasticUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text;

                    GameObject.FindGameObjectWithTag("PlasticUI")
                        .GetComponentInChildren<UnityEngine.UI.Text>()
                        .text = (Int32.Parse(textComponent) + 1).ToString();

                    break;
                }
        }
    }
}
