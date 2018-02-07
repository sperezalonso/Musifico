﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cassette : MonoBehaviour
{

    public static bool isCaught = false;

    Material mat;
    GameObject storage;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        storage = GameObject.Find("Caught Tapes");
    }

    void Update()
    {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            mat.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1"))
            {
                transform.SetParent(storage.transform);
                transform.position = storage.transform.position;

                // the cassette's audio file is played as long as the player hasn't found the final cassette
                // when this happens, the finished song is played instead
                if (CassetteManager.casCount < 6)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        else mat.DisableKeyword("_EMISSION");
    }
}
