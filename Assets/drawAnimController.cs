using System.Collections;
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
        if (Input.GetKeyDown("joystick button 0") && !isOpen)
        {
            anim.Play("drawerAnimation");
            isOpen = true;
        }
        else if (Input.GetKeyDown("joystick button 0") && isOpen)
        {
            anim.Play("drawerAnimationReverse");
            isOpen = false;
        }
    }
}
