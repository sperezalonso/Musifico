﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawAnimController : MonoBehaviour
{

    public Animator anim;
    bool isOpen = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		// for controller use GetKeyDown("joystick button 0") 
//		if (Input.GetKeyDown("space") && !isOpen)
//        {
//            anim.Play("drawerAnimation");
//            isOpen = true;
//        }
//        else if (Input.GetKeyDown("space") && isOpen)
//        {
//            anim.Play("drawerAnimationReverse");
//            isOpen = false;
//        }
    }

	public void open(){
		anim.Play("drawerAnimation");
	}

	public void close(){
		anim.Play("drawerAnimationReverse");
	}
}
