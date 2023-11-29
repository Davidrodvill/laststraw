using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Cutscene_Manager : MonoBehaviour {
    // Use this for initialization

    public GameObject SkipCutsceneButton;


    void Start()
    {

        StartCoroutine(Level2Cutscene1Wait());

    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator Level2Cutscene1Wait()
    {
        SkipCutsceneButton.SetActive(true);
        yield return new WaitForSecondsRealtime(12.02f);
        SceneManager.LoadScene(2);
    }
}
