using System.Collections;
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

            if (Input.GetKeyDown("space"))
            {
                GetComponent<AudioSource>().Play();
                //transform.gameObject.SetActive(false);
                transform.SetParent(storage.transform);
                transform.position = storage.transform.position;
                //isCaught = true;
                //transform.GetComponent<Renderer>().material = transparent;
                //lightbulb.gameObject.SetActive(true);
                //off = false;
            }
        }
        else mat.DisableKeyword("_EMISSION");
    }
}
