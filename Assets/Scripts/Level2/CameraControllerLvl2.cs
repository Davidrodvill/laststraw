using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLvl2 : MonoBehaviour {

	GameObject player;
	Vector3 offset;


	// Use this for initialization
	void Start () 
	{
        player = GameObject.Find("Player");

        offset = transform.position - player.transform.position;

    }
	
	// Update is called once per frame
	void Update () 
	{

        //camera position = offset + player position
        transform.position = offset + player.transform.position;

        //track player position
        Vector3 pos = offset + player.transform.position;



    }
}
