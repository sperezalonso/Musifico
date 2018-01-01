using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {

	Camera cardboardCam;
	LineRenderer laserLine;
	public float range = 60f;
	bool targetHit;
	float timer = 0f;
	bool isOpen = false;
	//public GameObject drawer;

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
			if (hit.collider.tag == "drawer")
			{
				targetHit = true;
				Debug.Log("I hit something, " + hit.collider.gameObject.name);
					
				if (Input.GetKeyDown ("space") && !isOpen) {
					if (hit.collider.gameObject.GetComponent<DrawerManager> ().whatDrawerAmI == DrawerManager.Drawers.drawerR1) {
						hit.collider.GetComponent<Animator> ().Play ("drawerAnimation");
						isOpen = true;
					}
					if (hit.collider.gameObject.GetComponent<DrawerManager> ().whatDrawerAmI == DrawerManager.Drawers.drawerR2) {
						hit.collider.GetComponent<Animator> ().Play ("drawerR2Open");
						isOpen = true;
					}
				}
				else if (Input.GetKeyDown("space") && isOpen)
				{
					if (hit.collider.gameObject.GetComponent<DrawerManager> ().whatDrawerAmI == DrawerManager.Drawers.drawerR1) {
						hit.collider.GetComponent<Animator> ().Play ("drawerAnimationReverse");
						isOpen = false;
					}
					if (hit.collider.gameObject.GetComponent<DrawerManager> ().whatDrawerAmI == DrawerManager.Drawers.drawerR2) {
						hit.collider.GetComponent<Animator> ().Play ("drawerR2Close");
						isOpen = false;
					}
				}


				//// count the time the user gazes at the target
				//timer += Time.deltaTime;

				//// User has to see the target for 2 seconds to load scene
				//if (targetHit && timer > 2)
				//{
				//    //restart both the regular and the round timer for the new test round
				//    timer = 0;
				//    roundTimer = 0;

				//    // change the scenario
				//    SetMeshesState(true);
				//    SetTargetState(false);
				//    scenario = "Test";
				//}
			}
			else targetHit = false;
		}
		// if the raycast doesn't hit anything
		else
		{
			laserLine.SetPosition(1, rayOrigin + (cardboardCam.transform.forward * range));
			timer = 0;
		}
	}
}