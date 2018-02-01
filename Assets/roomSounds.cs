using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSounds : MonoBehaviour {

    public AudioClip guitar1;
    public AudioClip guitar2;
    public AudioClip piano1;
    public AudioClip piano2;
    public AudioClip piano3;
    public AudioClip piano4;

    AudioClip source;
    Material mat;

    int guitar = 1;

    // Use this for initialization
    void Start () {
        mat = GetComponent<Renderer>().material;
        source = GetComponent<AudioSource>().clip;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            mat.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown("space"))
            {
                GetComponent<AudioSource>().Play();
                //if (transform.tag == "Guitar")
                //{
                //}
            }
        }
        else mat.DisableKeyword("_EMISSION");
	}
}
