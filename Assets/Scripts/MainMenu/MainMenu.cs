using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public PlayerController playercontroller;
	

	// Use this for initialization
	void Start () 
	{
		Screen.SetResolution(1920, 1080, true);
		

	}
	
	public void PlayGame()
	{
		SceneManager.LoadScene(1);


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

		SceneManager.LoadScene(1); //goes to level1 cutscene

	}

	public void OnLevel2Select()
	{
        SceneManager.LoadScene(3); //goes to level2 cutscene

    }

	public void OnLevel2CutsceneSelect()
	{
		SceneManager.LoadScene(5);

	}


}
