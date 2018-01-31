﻿using System.Collections;
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
            mat.SetFloat("_Outline", 0.026f);
            if (Input.GetKeyDown("space") && off)
            {
                transform.GetComponent<Renderer>().material = transparent;
                lightbulb.gameObject.SetActive(true);
                off = false;
            }
            else if (Input.GetKeyDown("space") && !off)
            {
                transform.GetComponent<Renderer>().material = opaque;
                mat = transform.GetComponent<Renderer>().material;
                lightbulb.gameObject.SetActive(false);
                off = true;
            }
        }
        else mat.SetFloat("_Outline", 0f);
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
