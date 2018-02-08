﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{

    Camera cardboardCam;
    LineRenderer laserLine;
    public float range = 75f;
    float timer = 0f;
    bool isOpen = false;
    Material mat;
    public GameObject flashlight;
    public static bool targetHit;
    public static Transform hitObject;
    public Text pointer;

    void Awake()
    {
        pointer.text = ".";
        cardboardCam = GetComponent<Camera>();
        laserLine = GetComponent<LineRenderer>();
        flashlight.SetActive(false);
        GameObject.FindWithTag("Licht").SetActive(true);
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

            // check if hit object is an interactable object
            if (hit.collider.tag == "Interaction")
            {
                //Debug.Log("I hit something, " + hit.collider.gameObject.name);
                if ((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1")) && !isOpen)
                {
                    hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Open");

                    if (hit.transform.name == "buch_0001c")
                    {
                        GameObject.FindWithTag("bookshelf").GetComponent<Animator>().Play("BookshelfCombinedOpen");
                    }
                    isOpen = true;
                }
                else if ((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1")) && isOpen)
                {
                    hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Close");
                    isOpen = false;
                }
            }

            if (hit.collider.tag == "Licht")
            {
                targetHit = true;

                if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1"))
                {
                    StartCoroutine("WaitAndHideFlashlight");
                }
            }

            //else targetHit = false;
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

    IEnumerator WaitAndHideFlashlight()
    {
        // suspend execution for 5 seconds
        GameObject.FindWithTag("Licht").GetComponent<Animator>().Play("flashlightOpen"); // plays flashlight animation
        yield return new WaitForSeconds(1);
        GameObject.FindWithTag("Licht").SetActive(false); // Make Flashlight invisible
        flashlight.SetActive(true); // turn on spotlight attached to camera
    }
}