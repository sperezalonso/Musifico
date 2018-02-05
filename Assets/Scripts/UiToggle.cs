using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToggle : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool panelVisibility = false;

    // Use this for initialization
    void Start()
    {
        inventoryPanel.SetActive(false);
    }

   // Update is called once per frame
   void Update()
	{
        if (Input.GetKeyDown("k") || Input.GetKeyDown("joystick button 2"))
		{
			Debug.Log("Working");
        }
		if (Input.GetKeyDown("k") && !panelVisibility)
		{
			inventoryPanel.SetActive(true);
			panelVisibility = true;
        }
        else if (Input.GetKeyDown("k") && panelVisibility)
        {
            inventoryPanel.SetActive(false);
            panelVisibility = false;
        }
    }
}
