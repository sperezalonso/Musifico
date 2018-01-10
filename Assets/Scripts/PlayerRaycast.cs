using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {

	Camera cardboardCam;
	LineRenderer laserLine;
	public float range = 60f;
	//bool targetHit;
	float timer = 0f;
	bool isOpen = false;

	void Awake()
	{
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

			// check if hit object is the test starter
			if (hit.collider.tag == "Interaction")
			{
                //Debug.Log("I hit something, " + hit.collider.gameObject.name);

                //Component halo = hit.transform.GetComponent("Halo");
                //halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
					
				if (Input.GetKeyDown ("space") && !isOpen) {
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
		}

		// if the raycast doesn't hit anything
		else
		{
			laserLine.SetPosition(1, rayOrigin + (cardboardCam.transform.forward * range));
			timer = 0;
		}
	}
}