using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSounds : MonoBehaviour
{

    public AudioClip guitar1;
    public AudioClip guitar2;
    public AudioClip piano1;
    public AudioClip piano2;
    public AudioClip piano3;
    public AudioClip piano4;

    AudioClip source;
    Material mat;

    bool guitarAudio = true;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        source = GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform == PlayerRaycast.hitObject && PlayerRaycast.targetHit)
        {
            mat.EnableKeyword("_EMISSION");

            if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1"))
            {
                // rotate the audio clips so that every time the player plays the guitar, a different clip is played

                guitarAudio = !guitarAudio;
                if (guitarAudio)
                    GetComponent<AudioSource>().clip = guitar1;
                else if (!guitarAudio)
                    GetComponent<AudioSource>().clip = guitar2;

                GetComponent<AudioSource>().Play();

                Debug.Log(guitarAudio + "   " + source);
                //if (transform.tag == "Guitar")
                //{
                //}
            }
        }
        else mat.DisableKeyword("_EMISSION");
    }
}
