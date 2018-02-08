// CASSETTE MANAGER
// Add to an empty GameObject Cassette Locations, whose children are the puzzle spots

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetteManager : MonoBehaviour
{
    GameObject[] cassettes;
    GameObject[] cassetteSpots;

    public GameObject caughtTapes;

    int index;
    int count = 0;
    float timer = 0f;
    bool playedFinalTrack = false;

    public static int casCount;                 // keep track of the found cassettes. Static because the value is used in the Cassette.cs script

    void Awake()
    {
        cassettes = new GameObject[transform.childCount];
        cassetteSpots = GameObject.FindGameObjectsWithTag("Spot");

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

    private void Update()
    {
        casCount = caughtTapes.transform.childCount;

        if (caughtTapes.transform.childCount == 7)
        {
            VictorySound();

            // let the final song play out, and close the application after one minute
            timer += Time.deltaTime;
            if (timer > 60) Application.Quit();
        }
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

    void VictorySound()
    {
        // if called multiple times during update, the song is never played (forever starting?). The bool value is used to play the final song only once
        if (!playedFinalTrack)
        {
            GetComponent<AudioSource>().Play();
            playedFinalTrack = true;
        }
    }
}
