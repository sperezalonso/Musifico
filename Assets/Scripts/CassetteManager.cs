// CASSETTE MANAGER
// Add to an empty GameObject Cassette Locations, whose children are the puzzle spots

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetteManager : MonoBehaviour
{

    GameObject[] cassettes;
    GameObject[] cassetteSpots;

    public GameObject test;

    int index;
    int count = 0;

    // Use this for initialization
    void Awake()
    {
        cassettes = new GameObject[transform.childCount];
        cassetteSpots = GameObject.FindGameObjectsWithTag("Spot");
        Debug.Log(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            cassettes[i] = transform.GetChild(i).gameObject;
            SpawnRandomly();
        }

        Debug.Log(cassetteSpots.Length + ",    " + cassettes.Length);
        //for (int i = 0; i < cassettes.Length; i++)
        //{
        //    SpawnRandomly(i);
        //}
    }

    void SpawnRandomly()
    {
        index = Random.Range(0, cassetteSpots.Length);
        if (cassetteSpots[index].transform.childCount == 0)
        {
            //GameObject newCassette = Instantiate(test, cassetteSpots[index].transform.position, cassetteSpots[index].transform.rotation);
            GameObject newCassette = cassettes[count].gameObject;
            newCassette.transform.SetParent(cassetteSpots[index].transform);
            newCassette.transform.position = cassetteSpots[index].transform.position;
            //newCassette.transform.rotation = cassetteSpots[index].transform.rotation;
            count++;
        }
        else SpawnRandomly();
    }
}
