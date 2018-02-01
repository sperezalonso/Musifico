using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {

    public static bool isHit;

    Material mat;

    // Use this for initialization
    void Start () {
        //if (transform.parent.name == "closet" || transform.parent.name == "tvTable" || transform.parent.name == "windowTable") 
        if (transform.name == "flashlight")
        {
            //Debug.Log("WORKING WORKS");
            mat = transform.GetChild(0).GetComponent<Renderer>().materials[1];
        }
        else if (transform.parent.tag == "ComplexFurniture")
        {
            //Debug.Log("THis is working");
            mat = transform.GetChild(0).GetComponent<Renderer>().material;
        }
        else mat = GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            //mat.SetFloat("_Outline", 0.026f);
            mat.EnableKeyword("_EMISSION");
        }
        //else mat.SetFloat("_Outline", 0f);
        else mat.DisableKeyword("_EMISSION");
    }
}
