using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {

    public static bool isHit;

    Material mat;

    // Use this for initialization
    void Start () {
        if (transform.parent.name == "closet")
        {
            Debug.Log("THis is working");
            mat = transform.GetChild(0).GetComponent<Renderer>().material;
        }
        else mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            mat.SetFloat("_Outline", 0.026f);
        }
        else mat.SetFloat("_Outline", 0f);
    }
}
