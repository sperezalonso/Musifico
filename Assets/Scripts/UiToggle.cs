﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToggle : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool panelVisibility = false;
    GameObject[] tapes; 
    GameObject caughtTapes; 
    public GameObject[] icons;
    // Use this for initialization
    void Start()
    {
        //inventoryPanel.SetActive(false);
        tapes = GameObject.FindGameObjectsWithTag("tape");
        caughtTapes = GameObject.Find("Caught Tapes");

        inventoryPanel.GetComponent<CanvasRenderer>().SetAlpha(0f); //set the opacity of inventory panels to 0 
        icons = GameObject.FindGameObjectsWithTag("UI");

        //hide all inventory icons
        for (int i = 0; i < icons.Length; i++){
            icons[i].GetComponent<CanvasRenderer>().SetAlpha(0.5f); //set opacity of icons to 0.5 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle inventory panel 

        if ((Input.GetKeyDown("k") || Input.GetKeyDown("joystick button 2")) && !panelVisibility)
        {
        //inventoryPanel.SetActive(true);
            inventoryPanel.GetComponent<CanvasRenderer>().SetAlpha(1f);
			panelVisibility = true;
        }
        else if ((Input.GetKeyDown("k") || Input.GetKeyDown("joystick button 2")) && panelVisibility)
        {
            Debug.Log("inventory is visible now");
            //inventoryPanel.SetActive(false);
            inventoryPanel.GetComponent<CanvasRenderer>().SetAlpha(0f);
            panelVisibility = false;
        }

        //Set opacity of icons to 100% depending on the collected Cassettes 
        for (int i = 0; i < tapes.Length; i++)
        {
            if (tapes[i].transform.parent == caughtTapes.transform)
            {
                Debug.Log("tape found");
        
                switch (tapes[i].name){
                    case "cassette1":
                        showCassetteIcon(1);
                    break;
				case "cassette2":
						showCassetteIcon(2);
						break;
				case "cassette3":
						showCassetteIcon(3);
						break;
				case "cassette4":
						showCassetteIcon(4);
						break;
				case "cassette5":
						showCassetteIcon(5);
						break;
				case "cassette6":
						showCassetteIcon(6);
						break;
				case "cassette7":
						showCassetteIcon(7); 
						break;

                default:
                        Debug.Log("no cassette found");
			        break;
            }

            }
        }
    }

    void showCassetteIcon(int i){
        GameObject.Find("TapeIcon" + i).GetComponent<CanvasRenderer>().SetAlpha(1f);
    }

    public void playCassette(int i){
        GameObject.Find("cassette" + i).GetComponent<AudioSource>().Play();
    }
  

}
