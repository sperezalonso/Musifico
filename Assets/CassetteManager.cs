﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetteManager : MonoBehaviour {

    public GameObject cassette;

    GameObject[] cassetteSpots;
    int index;

    // Use this for initialization
    void Awake()
    {
        cassetteSpots = GameObject.FindGameObjectsWithTag("SpotTest");
        Debug.Log(cassetteSpots.Length);


        for (int i = 0; i < 5; i++)
        {
            //GameObject newCassette = Instantiate(cassette);
            //index = Random.Range(0, cassetteSpots.Length);

            SpawnRandomly();

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnRandomly( )
    {
        index = Random.Range(0, cassetteSpots.Length);
        if (cassetteSpots[index].transform.childCount == 0)
        {
            GameObject newCassette = Instantiate(cassette, cassetteSpots[index].transform.position, cassetteSpots[index].transform.rotation);
            newCassette.transform.SetParent(cassetteSpots[index].transform);
        }
        else SpawnRandomly();
    }
}
