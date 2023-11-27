using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public PlayerController playercontroller;
	

	// Use this for initialization
	void Start () 
	{
		
		

	}
	
	public void PlayGame()
	{
		SceneManager.LoadScene(0);


	}

	public void QuitGame()
	{
		Debug.Log("QUIT!!!");
		Application.Quit();
		


	}

	public void Biographies()
	{


	}

	public void OnLevel1Select()
	{
		//if level 1 is selected, level 1 will load

		SceneManager.LoadScene(0);

	}

	public void OnLevel2Select()
	{

        //if level 2 is selected, AND level 1 has been completed, level 2 will load

        //if level 2 is selected, and level 1 has NOT been completed, level 2 will not load and a message will show.
    }



}
