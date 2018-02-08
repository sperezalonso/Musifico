using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    bool GameIsPaused;
    public GameObject PauseMenuUI;

    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown("p") || Input.GetKeyDown("joystick button 3")){
            if(!GameIsPaused){
				Paused();
                Debug.Log("game paused");
            }
            else
            {
				Resume();
                Debug.Log("game resumed");
            }
        }
	}


    void Paused(){
        Debug.Log("method paused");
        PauseMenuUI.GetComponent<Animator>().Play("inventoryOpen");
        //Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    void Resume(){
        PauseMenuUI.GetComponent<Animator>().Play("inventoryClose");
		Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

}
