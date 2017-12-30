using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //script to move the player in the scene exactly as you would move in an FPS game

    float distance = 5f;
    public float speed = 40.0f;
    GameObject hmdCam;
	float horizontalSpeed = 7.0f;
	float verticalSpeed = 7.0f;

    void Awake()
    {
        hmdCam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;       // Keyboard input
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Follow the Vive cam so that the headset rig moves forward in the direction the Vive is facing
        transform.position += (hmdCam.transform.right * x + hmdCam.transform.forward * z) * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);       // This is done so that the player stays on the ground

		//Rotates Player on "X" Axis Acording to Mouse Input
		float h = horizontalSpeed * Input.GetAxis ("Mouse X");
		transform.Rotate (0, h, 0);

		//Rotates Player on "Y" Axis Acording to Mouse Input
		float v = verticalSpeed * Input.GetAxis ("Mouse Y");
		Camera.main.transform.Rotate (v, 0, 0);
    }
}
