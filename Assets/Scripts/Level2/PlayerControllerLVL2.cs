using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;
public class PlayerControllerLVL2 : MonoBehaviour {

    public float _playerSpeed = 3f; //_playerSpeed is how fast the player moves
    //public float maxSpeed = 15f;
    public float hSpeed = 3f, vSpeed = 3f, punchSpeed = 1f;
    public int hp = 100, onemores, numOfHivesLeft = 13;
    public Transform healthBarPos;
    public Slider healthBar;
    Animator anim;
    public Color color1Player;
    public Color color2Player;
    public SpriteRenderer sr1;
    public GameObject pauseTextBox; //atkPunches;
    public Transform punchSpawner;
    public float Cooldown = 0.5f;
    public float _nexthit = 0f;
    public Text pauseText;
    Rigidbody2D rb2d; // reference to RigidBody2d
    public EnemyController enemyController;
    public VideoPlayer vp1, vp2, vp3;
    public GameObject MoralityCutsceneOpen, GoodMoralityChoiceCutscene, BadMoralityChoiceCutscene;
    public Button goodChoiceButton, badChoiceButton, mainMenuButton;
    //public bool bossKilled = false; //In order to use this, youll need to create a new EnemyController script for the boss

    public bool moving = false, facingRight, facingLeft, facingUp, facingDown;
    
    public bool canMove = true, die = false, win = false, gamePaused;
    // Use this for initialization
    void Start () {

        numOfHivesLeft = 13;
        GameObject hb = Instantiate(healthBar.gameObject);
        //put the healthbar on the canvas
        hb.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar = hb.GetComponent<Slider>();

        mainMenuButton.gameObject.SetActive(false);
        pauseText.text = "";

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        pauseTextBox.SetActive(false);
        goodChoiceButton.gameObject.SetActive(false);
        badChoiceButton.gameObject.SetActive(false);

        
        BadMoralityChoiceCutscene.SetActive(true);

        /*
        vp1.enabled = false;
        vp1.gameObject.SetActive(false);

        vp2.enabled = false;
        vp2.gameObject.SetActive(false);

        vp3.enabled = false;
        vp3.gameObject.SetActive(false);
        */
        

    }
	
    void Update()
    {
        //update heath bar
        healthBar.transform.position = Camera.main.WorldToScreenPoint(healthBarPos.transform.position);
        healthBar.value = hp;

        

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
	void FixedUpdate () {

        

        Vector3 pos = Camera.main.WorldToViewportPoint(
            transform.position);

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            moving = false;
            anim.SetBool("IsMoving", false);
        }

        

        if (canMove)
        {
            //4 directional movement (top-down)
            if (Input.GetAxisRaw("Vertical") > 0 && pos.y < 0.96f) //up
            {
                transform.position += new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;

                transform.rotation = Quaternion.Euler(pos.x, pos.y, 0);

                if(moving == true)
                anim.SetBool("IsMoving", true);

               //if facing up, nothing changes
               if(facingDown)
                {
                    facingDown = false;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                
            }
            if (Input.GetAxisRaw("Vertical") < 0 && pos.y > 0.01f) //down
            {
                facingDown = true;
                transform.position -= new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;

                transform.rotation = Quaternion.Euler(pos.x, pos.y, 180);

                if (moving == true)
                anim.SetBool("IsMoving", true);

                if(!facingDown)
                {
                    facingDown = true;
                    //if facing down, sprite's rotation should flip
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -transform.localScale.z);
                }
                

                //if stops moving, set StopsFlying trigger here true

            }
            if (Input.GetAxisRaw("Horizontal") > 0 && pos.x < 0.96f) //right
            {
                Debug.Log("D key has been pressed");
                transform.position += new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;

                transform.rotation = Quaternion.Euler(pos.x, pos.y, 270);

                if (moving == true)
                anim.SetBool("IsMoving", true);

                if(!facingRight)
                {
                    facingRight = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }


                //if we were facing left, flip

            }
            if (Input.GetAxisRaw("Horizontal") < 0 && pos.x > 0.01f) //left
            {
                transform.position -= new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;

                transform.rotation = Quaternion.Euler(pos.x, pos.y, 90);

                if (facingRight)
                {
                    facingRight = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }


            }
            if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.S)))
                {
                transform.rotation = Quaternion.Euler(pos.x, pos.y, 135);
                
            }
            if((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.W)))
            {
                transform.rotation = Quaternion.Euler(pos.x, pos.y, 45);

            }
            if((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.W)))
            {
                transform.rotation = Quaternion.Euler(pos.x, pos.y, 315);

            }
            if((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.S)))
            {
                transform.rotation = Quaternion.Euler(pos.x, pos.y, 225);

            }

            //if stops moving, set StopsFlying trigger here true
            if (moving == false)
            {
                anim.SetBool("IsMoving", false);

            }


           
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bees")
        {
            TakeDamage(enemyController.attackDamage);

            //hp -= enemyController.attackDamage;

        }

        if(other.tag == "BossBee")
        {
            TakeDamage(enemyController.attackDamage);


        }

    }

    
    public void OneHiveDestroyed()
    {
        numOfHivesLeft--;
        Debug.Log("A hive down");
        //onemores += hivesdestroyed;

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

        
    }
    

    void PauseGame()
    {
        pauseTextBox.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0;
        pauseText.text = "PAUSED";
        AudioListener.pause = true;
        canMove = false;
        mainMenuButton.gameObject.SetActive(true);

    }

    void ResumeGame()
    {
        pauseTextBox.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
        pauseText.text = "";
        AudioListener.pause = false;
        canMove = true;
        mainMenuButton.gameObject.SetActive(false);

        //PauseGame();

        

    }

    public void OnMainMenuButtonPress()
    {
        //game should quit to main menu
        SceneManager.LoadScene(3);

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player has been hurt");

        hp -= damage;

        StartCoroutine(PlayerDamaged());

        if(hp <= 0)
        {

            //create coroutine that just restarts the level, just like level 1
        }

    }

    IEnumerator PlayerDamaged()
    {
        sr1.color = color2Player;
        yield return new WaitForSeconds(.5f);
        sr1.color = color1Player;

    }



    IEnumerator MoralityChoiceButtonSetActive()
    {
        Debug.Log("IF YOU SEE ME, THINGS ARE GOOD");

        yield return new WaitForSecondsRealtime(22.887f);

        
        goodChoiceButton.gameObject.SetActive(true);
        badChoiceButton.gameObject.SetActive(true);
        goodChoiceButton.enabled = true; ///////////////////////////////////////////////////////////////
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
        ResumeGame();
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
        ResumeGame();
        SceneManager.LoadSceneAsync(3);

    }


}
