using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

	Camera cardboardCam;
	LineRenderer laserLine;
	public float range = 60f;
	float timer = 0f;
	bool isOpen = false;
	Material mat;
    public GameObject flashlight;
	public static bool targetHit;
	public static Transform hitObject;

	void Awake()
	{
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
            //mat = hit.collider.GetComponent<Renderer>().material;
            hitObject = hit.collider.transform;

            // check if hit object is an interactable object
            if (hit.collider.tag == "Interaction")
            {
                targetHit = true;
                //Debug.Log("I hit something, " + hit.collider.gameObject.name);

                if (Input.GetKeyDown("space") && !isOpen)
                {

                    //drawer animations
                    hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Open");
                    isOpen = true;

                    //hidden door animation

                }
                else if (Input.GetKeyDown("space") && isOpen)
                {
                    hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Close");
                    isOpen = false;
                }
            }
            //if (hit.collider.tag == "OutlineTest")
            //{
            //    //mat.SetFloat("_Outline", 0.026f);
            //    targetHit = true;

            //    if (Input.GetKeyDown("space") && !isOpen)
            //    {

            //        //drawer animations
            //        hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Open");
            //        isOpen = true;

            //        //hidden door animation

            //    }
            //    else if (Input.GetKeyDown("space") && isOpen)
            //    {
            //        hit.collider.GetComponent<Animator>().Play(hit.transform.name + "Close");
            //        isOpen = false;
            //    }
            //}

			if (hit.collider.tag == "Licht")
			{
				targetHit = true;

				if (Input.GetKeyDown("space"))
				{
					GameObject.FindWithTag("Licht").SetActive(false); // Make Flashlight invisible
					flashlight.SetActive(true); // turn on spotlight attached to camera
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
		}
	}

	//void FadeText()
	//{
	//    if (displayInfo)
	//    {
	//        myText.text = myString;
	//        myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
	//    }

	//    else
	//    {
	//        myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
	//    }
	//}
}