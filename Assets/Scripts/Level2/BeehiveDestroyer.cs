using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeehiveDestroyer : MonoBehaviour {

	PlayerControllerLVL2 pc2;
	Beehives beehives;

	public int numOfHivesLeft = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		numOfHivesLeft = (numOfHivesLeft - 1);
	}



    public void OneHiveDestroyed()
    {
        numOfHivesLeft = (numOfHivesLeft - 1);
        Debug.Log("A hive down");
        //onemores += hivesdestroyed;

        /*
        if(numOfHivesLeft <= 0)
        {
            //win game
            Debug.Log("all 13 hives down");

            winGame = true;

            /*
            if(winGame == true)
            {
                SceneManager.LoadScene(5);
            }
            
        }
        */

        /*
        if (numOfHivesLeft <= 0)
        {
            //win game
            Debug.Log("all 13 hives down");
            
            vp1.enabled = true;
            vp1.gameObject.SetActive(true);            //////////////////////////////////////////
            vp1.waitForFirstFrame = true;
            Debug.Log("You have beat the level!");

            //cutscene plays here, signaling the end of the level.

            MoralityCutsceneOpen.SetActive(true);
            StartCoroutine(MoralityChoiceButtonSetActive());
            
        }
        */

    }

}
