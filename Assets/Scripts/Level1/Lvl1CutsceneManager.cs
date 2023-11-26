using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lvl1CutsceneManager : MonoBehaviour {

	// Use this for initialization

	public GameObject SkipCutsceneButton;


    void Start () {

		StartCoroutine(Level1Cutscene1Wait());

	}
	
	public void SkipCutscene()
	{
		SceneManager.LoadScene(1);
	}

    IEnumerator Level1Cutscene1Wait()
	{
        SkipCutsceneButton.SetActive(true);
        yield return new WaitForSecondsRealtime(61f);
		SceneManager.LoadScene(1);
    }

}
