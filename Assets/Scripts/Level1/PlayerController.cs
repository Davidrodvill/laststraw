using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;
using UnityEngine.Assertions.Must;

public class PlayerController : MonoBehaviour
{
   
    public float _playerSpeed = 5f; //_playerSpeed is how fast the player moves
    //public float maxSpeed = 15f;
    public float hSpeed = 10f, vSpeed = 6f;
    public float speed = 15; //for thrust
    public float jump = 200;
    public float Cooldown = 5f;
    public float _nexthit = 0f;
    public float progressValue = 0.01f;
    public int hp = 10;
    public Slider healthBar, progressMeter;
    public GameObject platTest1, platTest2, dialogue_box, blackoutSquare, SkipCutsceneButton;
    Animator anim;
    public Color color1Player;
    public Color color2Player;
    public SpriteRenderer sr1;
    public VideoPlayer vp1, vp2, vp3;
    //public GameObject Lvl1Cutscene1;
    public GameObject MoralityCutsceneOpen, GoodMoralityChoiceCutscene, BadMoralityChoiceCutscene;
    public Button goodChoiceButton, badChoiceButton, mainMenuButton;

    public Text dialogues, playerName, pauseText, levelUnlock;

    public bool moving = false;
    public bool faceRight = true;
    public bool canMove = true, die = false, win = false, gamePaused, level2Unlock;



    Rigidbody2D rb2d; // reference to RigidBody2d

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        faceRight = true;
        anim = GetComponent<Animator>();
        dialogue_box.SetActive(false);
        dialogues.text = "";
        pauseText.text = "";
        levelUnlock.text = "";
        vp1.enabled = false;
        vp1.gameObject.SetActive(false);

        vp2.enabled = false;
        vp2.gameObject.SetActive(false);

        vp3.enabled = false;
        vp3.gameObject.SetActive(false);

        mainMenuButton.gameObject.SetActive(false);
        //Lvl1Cutscene1.SetActive(true);
        //SkipCutsceneButton.SetActive(false); //will be set to true only if/when cutscene starts
        //goodChoiceButton.enabled = false;
        //badChoiceButton.enabled = false;
        goodChoiceButton.gameObject.SetActive(false);
        badChoiceButton.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused) //pauses game
        {

            PauseGame();

        }


        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused) //unpauses game
        {

            ResumeGame();

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //dialogue
        if (Input.GetKey(KeyCode.T))
        {
            dialogue_box.SetActive(true);
            dialogues.text = "im goku";
        }
        healthBar.value = hp;

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            moving = false;
        }

        //Get the player Position on screen (0-1 in x and y)
        Vector3 pos = Camera.main.WorldToViewportPoint(
            transform.position);

        if (canMove)
        {
            //4 directional movement (top-down)
            if (Input.GetAxisRaw("Vertical") > 0 && pos.y < 0.98f) //up
            {
                transform.position += new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;
                anim.SetBool("StartsFlying", true);
                anim.SetBool("IsMoving", true);
                anim.SetBool("StopsFlying", false);

                //if stops moving, set StopsFlying trigger here true
                if (moving == false)
                {
                    //anim.SetTrigger("StopsFlying");
                }
            }
            if (Input.GetAxisRaw("Vertical") < 0 && pos.y > 0.02f) //down
            {
                transform.position -= new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;
                anim.SetBool("StartsFlying", true);
                anim.SetBool("IsMoving", true);
                anim.SetBool("StopsFlying", false);

                //if stops moving, set StopsFlying trigger here true

            }
            if (Input.GetAxisRaw("Horizontal") > 0 && pos.x < 0.98f) //right
            {
                Debug.Log("D key has been pressed");
                transform.position += new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;
                anim.SetBool("StartsFlying", true);
                anim.SetBool("IsMoving", true);
                anim.SetBool("StopsFlying", false);

                //progress meter
                progressMeter.value += progressValue;
               

                //if we were facing left, flip
                if (!faceRight)
                {
                    faceRight = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && pos.x > 0.02f) //left
            {
                transform.position -= new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;
                anim.SetBool("StartsFlying", true);
                anim.SetBool("IsMoving", true);
                anim.SetBool("StopsFlying", false);

                //if stops moving, set StopsFlying trigger here true
                //progress meter
                progressMeter.value -= progressValue;

                //if we were facing right, flip
                if (faceRight)
                {
                    faceRight = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }
            }

            //if stops moving, set StopsFlying trigger here true
            if (moving == false)
            {
                anim.SetBool("StartsFlying", false);
                anim.SetBool("StopsFlying", true);
                anim.SetBool("IsMoving", false);
            }

            
            //when player stops moving (lets go of the key), set moving = false
            /*
            if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
            {
                Debug.Log("all keys has been let go");
                moving = false;

                anim.SetBool("StartsFlying", false);
                anim.SetBool("IsMoving", false);
                anim.SetBool("StopsFlying", true);
            }
            */
        }

        /*
        //made it GetKeyDown so its easier for the transition animations can play
        //nvm this shit doesn't work omfg fuck this project
        if(Input.GetKeyDown(KeyCode.A)) //left
        {

            transform.position -= new Vector3(
                _playerSpeed * Time.deltaTime, 0);
            moving = true;
            faceRight = false;

            if(Input.GetKeyUp(KeyCode.A)) //if A key is let go
            {
                moving = true;
                //transform.position -= new Vector3(_playerSpeed * Time.deltaTime, 0);

            }

        }

        if(Input.GetKeyDown(KeyCode.D)) //right
        {


            transform.position += new Vector3(_playerSpeed * Time.deltaTime, 0);
            moving = true;
            faceRight = true;
        }

        if(Input.GetKeyDown(KeyCode.W)) //up
        {

            transform.position += new Vector3(0, _playerSpeed * Time.deltaTime);
            moving = true;
        }

        if(Input.GetKeyDown(KeyCode.S)) //down
        {

            transform.position -= new Vector3(0, _playerSpeed * Time.deltaTime);
            moving = true;
        }
        */






        //ORIGINAL

        /*
        if (Input.GetAxisRaw("Horizontal") > 0 && pos.x < 0.96f) //right
            {
                transform.position += new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
                //faceRight = true;

                //if we were facing left, flip
                if (!faceRight)
                {
                    faceRight = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && pos.x > 0.1f) //left
            {
                transform.position -= new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
                faceRight = false;

                //if we were facing right, flip
                if (faceRight)
                {
                    faceRight = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }

            }
            if (Input.GetAxisRaw("Vertical") == 1) //up
            {
                //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)
                //rb2d.velocity = transform.up * _playerSpeed;
                transform.position += new Vector3(0, _playerSpeed * Time.deltaTime);
                moving = true;
            }
            if (Input.GetAxisRaw("Vertical") == -1) //down
            {
                transform.position -= new Vector3(0, _playerSpeed * Time.deltaTime);
                moving = true;
            }
            
        }
        */

        //Thruster (F)
        if (Input.GetKeyDown(KeyCode.F) && (Time.time > _nexthit))
        {
            if (faceRight)
            {
                transform.position += new Vector3(speed * 10 * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(speed * 10 * Time.deltaTime, 0);
            }
            _nexthit = Time.time + Cooldown; //coldown timer add
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if(other.tag == "CutsceneStart")
        {

            Debug.Log("Cutscene should play here");
            Destroy(other.gameObject);
            SkipCutsceneButton.SetActive(true);


            //StartCoroutine(Level1Cutscene1Wait());

        }
        */

        if(other.tag == "EndOfLevel")
        {
            vp1.enabled = true;
            vp1.gameObject.SetActive(true);
            vp1.waitForFirstFrame = true;
            Debug.Log("You have beat the level!");
            level2Unlock = true;
            win = true;

            //everything here gets disabled first
            PauseGame();
            

            //cutscene plays here, signaling the end of the level.

            MoralityCutsceneOpen.SetActive(true);
            StartCoroutine(MoralityChoiceButtonSetActive());

            
            /*
            if(goodChoiceButton == true)
            {
                vp1.enabled = false;
                MoralityCutsceneOpen.SetActive(false);

                vp2.enabled = true;
                GoodMoralityChoiceCutscene.SetActive(true);
                StartCoroutine(GoodChoiceCutsceneWait());
            }

            if(badChoiceButton == true)
            {
                vp1.enabled = false;
                MoralityCutsceneOpen.SetActive(false);

                vp3.enabled = true;
                BadMoralityChoiceCutscene.SetActive(true);
                StartCoroutine(BadChoiceCutsceneWait());

            }
            */

        }

        if (other.tag == "NormalCar")
        {
            StartCoroutine(PlayerDamaged());
            //player takes damage
            hp--;

            Debug.Log("Player has been hit by a NormalCar");

            
        }
        

        if (other.tag == "BigCar") //big cars do a bit more damage
        {
            StartCoroutine(PlayerDamaged());
            //player takes 2 damage
            hp = (hp - 2);

            Debug.Log("Player has been hit by a BigCar. That hurt.");
        }

        else if (hp <= 0 || hp == 0)
        {
            Die();
        }

    }

    void Die()
    {
        canMove = false;
        moving = false;
        GetComponent<PolygonCollider2D>().enabled = false;

        //screen will fade to black then reload the scene
        StartCoroutine(FadeBlackOutSquare());
       

    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1) //fade to black after death
    {

        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackoutSquare.GetComponent<Image>().color.a < 1)
            {

                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

        }
        else
        {

            while (blackoutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;

            }

        }

        //after screen fully fades, respawn level

        //yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(1);
        


    }

    /*
    IEnumerator Level1Cutscene1Wait()
    {
        SkipCutsceneButton.SetActive(true);
        PauseGame();
        
        Debug.Log("game has been paused for the opening cutscene");
        yield return new WaitForSecondsRealtime(61f);
        Lvl1Cutscene1.SetActive(false);

        ResumeGame();
        SkipCutsceneButton.SetActive(false);
        
        
        
    }
*/
    IEnumerator PlayerDamaged()
    {

        sr1.color = color2Player;
        yield return new WaitForSeconds(.5f);
        sr1.color = color1Player;

    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        pauseText.text = "PAUSED";
        AudioListener.pause = true;
        canMove = false;
        mainMenuButton.gameObject.SetActive(true);


    }

   public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        pauseText.text = "";
        AudioListener.pause = false;
        canMove = true;
        mainMenuButton.gameObject.SetActive(false);

    }

    /*
    public void SkipCutscene()
    {
        if(vp1 == enabled)
        {
            vp1.Stop();
            Lvl1Cutscene1.SetActive(false);
            Debug.Log("you have skipped the cutscene");
            ResumeGame();
            SkipCutsceneButton.SetActive(false);
            //music1.Play();

        }

    }
    */

    IEnumerator MoralityChoiceButtonSetActive()
    {
        Debug.Log("IF YOU SEE ME, THINGS ARE GOOD");

        yield return new WaitForSecondsRealtime(15f);

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

        yield return new WaitForSecondsRealtime(17.572f);
        //yield return new WaitForSecondsRealtime(18f);
        //yield return new WaitForSecondsRealtime(23f);

        levelUnlock.text = "Level 2 Has Been Unlocked.";


        yield return new WaitForSecondsRealtime(5f);
        //will go back to main menu, but for now will load level 2
        ResumeGame();
        SceneManager.LoadSceneAsync(4);
    }


    IEnumerator BadChoiceCutsceneWait()
    {

        yield return new WaitForSecondsRealtime(52.062f);
        //yield return new WaitForSecondsRealtime(52f);
        //yield return new WaitForSecondsRealtime(57f);

        levelUnlock.text = "Level 2 Has Been Unlocked.";

        yield return new WaitForSecondsRealtime(5f);
        //will go back to main menu, but for now will load level 2
        ResumeGame();
        SceneManager.LoadSceneAsync(4);

    }

    public void OnGoodChoicePress()
    {
        vp1.gameObject.SetActive(false);
        vp1.enabled = false;
        MoralityCutsceneOpen.SetActive(false);

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

        vp3.enabled = true;
        vp3.gameObject.SetActive(true);
        BadMoralityChoiceCutscene.SetActive(true);
        StartCoroutine(BadChoiceCutsceneWait());

    }

    public void OnMainMenuButtonPress()
    {
        //game should quit to main menu
        SceneManager.LoadScene(3);

    }
}
        



    
   


