using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Level2_Cutscenemanager : MonoBehaviour
{

    public VideoPlayer vp1, vp2, vp3;
    public GameObject MoralityCutsceneOpen, GoodMoralityChoiceCutscene, BadMoralityChoiceCutscene;
    public Button goodChoiceButton, badChoiceButton;
    //public PlayerControllerLVL2 pc2;

    // Use this for initialization
    void Start()
    {

        goodChoiceButton.gameObject.SetActive(false);
        badChoiceButton.gameObject.SetActive(false);

        
        vp1.enabled = true;
        vp1.gameObject.SetActive(true);

        vp2.enabled = false;
        vp2.gameObject.SetActive(false);

        vp3.enabled = false;
        vp3.gameObject.SetActive(false);
        


        Debug.Log("AAAAAAAHHHHHHH");

        vp1.enabled = true;
        vp1.gameObject.SetActive(true);            //////////////////////////////////////////
        vp1.waitForFirstFrame = true;
        Debug.Log("You have beat the level!");

        //cutscene plays here, signaling the end of the level.

        MoralityCutsceneOpen.SetActive(true);
        StartCoroutine(MoralityChoiceButtonSetActive());

    }

    // Update is called once per frame
    void Update()
    {














    }

    public void OnGoodChoicePress()
    {
        vp1.gameObject.SetActive(false);
        vp1.enabled = false;
        MoralityCutsceneOpen.SetActive(false);
        goodChoiceButton.gameObject .SetActive(false);
        badChoiceButton.gameObject.SetActive(false);


        vp2.enabled = true;
        vp2.gameObject.SetActive(true);
        GoodMoralityChoiceCutscene.SetActive(true);
        StartCoroutine(GoodChoiceCutsceneWait());
    }


    public void OnBadChoicePress()
    {
        vp1.enabled = false;
        vp1.gameObject.SetActive(false);
        MoralityCutsceneOpen.SetActive(false);
        goodChoiceButton.gameObject.SetActive(false);
        badChoiceButton.gameObject.SetActive(false);

        vp3.enabled = true;
        vp3.gameObject.SetActive(true);
        BadMoralityChoiceCutscene.SetActive(true);
        StartCoroutine(BadChoiceCutsceneWait());

    }


    IEnumerator MoralityChoiceButtonSetActive()
    {
        Debug.Log("IF YOU SEE ME, THINGS ARE GOOD");

        yield return new WaitForSecondsRealtime(22.887f);


        goodChoiceButton.gameObject.SetActive(true);
        badChoiceButton.gameObject.SetActive(true);
        goodChoiceButton.enabled = true;
        badChoiceButton.enabled = true;
        Debug.Log("Good choice button is set to: " + goodChoiceButton.enabled);
        Debug.Log("bad choice button is set to: " + badChoiceButton.enabled);


        Debug.Log("BUTTONS SHOULD BE SET ACTIVE HERE");


    }

    IEnumerator GoodChoiceCutsceneWait()
    {

        yield return new WaitForSecondsRealtime(8.627f);
        //yield return new WaitForSecondsRealtime(18f);
        //yield return new WaitForSecondsRealtime(23f);

        //levelUnlock.text = "Level 2 Has Been Unlocked.";


        yield return new WaitForSecondsRealtime(2f);
        //will go back to main menu, but for now will load level 2
        //pc2.GetComponent<PlayerControllerLVL2>().ResumeGame();
        SceneManager.LoadSceneAsync(3);
    }


    IEnumerator BadChoiceCutsceneWait()
    {

        yield return new WaitForSecondsRealtime(11.437f);
        //yield return new WaitForSecondsRealtime(52f);
        //yield return new WaitForSecondsRealtime(57f);

        //levelUnlock.text = "Level 2 Has Been Unlocked.";

        yield return new WaitForSecondsRealtime(2f);
        //will go back to main menu, but for now will load level 2
        //pc2.GetComponent<PlayerControllerLVL2>().ResumeGame();
        SceneManager.LoadSceneAsync(3);

    }


}
