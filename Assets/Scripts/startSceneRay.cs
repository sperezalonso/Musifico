﻿﻿﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startSceneRay : MonoBehaviour
{
    Camera cardboardCam;
    LineRenderer laserLine;
    public float range = 75f;
    float timer = 0f;
    bool isOpen = false;
    Material mat;
    //public GameObject flashlight;
    public static bool targetHit;
    public static Transform hitObject;
    public Text pointer;
    public Button startButton;
    void Awake()
    {
        pointer.text = ".";
        cardboardCam = GetComponent<Camera>();
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // set ray to center of the screen/camera
        Vector3 rayOrigin = cardboardCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        // set starting point of the laser
        laserLine.SetPosition(0, cardboardCam.transform.position);

        // if the raycast hits an object
        if (Physics.Raycast(rayOrigin, cardboardCam.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
            hitObject = hit.collider.transform;
                targetHit = true;


            if(hit.collider.tag == "Button"){
                Debug.Log("I hit something, ");

				if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1"))
				{
                    GameObject.FindWithTag("Button").GetComponent<LoadOnClick>().LoadScene(1);
				}
            }
        }
        
        // if the raycast doesn't hit anything
        else
        {
            laserLine.SetPosition(1, rayOrigin + (cardboardCam.transform.forward * range));
            timer = 0;
            targetHit = false;
            hitObject = null;
        }
    }
          
}