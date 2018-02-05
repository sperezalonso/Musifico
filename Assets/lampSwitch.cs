using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampSwitch : MonoBehaviour
{

    Material mat;
    bool off = true;
    Transform lightbulb;

    public Material opaque;
    public Material transparent;

    // Use this for initialization
    void Start()
    {
        mat = transform.GetComponent<Renderer>().material;
        lightbulb = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            mat.EnableKeyword("_EMISSION");
            if ((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1")) && off)
            {
                transform.GetComponent<Renderer>().material = transparent;
                lightbulb.gameObject.SetActive(true);
                off = false;
            }
            else if ((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1")) && !off)
            {
                transform.GetComponent<Renderer>().material = opaque;
                mat = transform.GetComponent<Renderer>().material;
                lightbulb.gameObject.SetActive(false);
                off = true;
            }
        }
        else mat.DisableKeyword("_EMISSION");
    }
}

//if (transform == PlayerRaycast.hitObject && Input.GetKeyDown("space"))
//        {
//            if (off)
//            {
//                transform.GetComponent<Renderer>().material = transparent;
//                lightbulb.gameObject.SetActive(true);
//                off = false;
//            }
//            else
//            {
//                transform.GetComponent<Renderer>().material = opaque;
//                lightbulb.gameObject.SetActive(false);
//                off = true;
//            }
//        }
