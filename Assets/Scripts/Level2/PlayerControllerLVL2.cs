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
    public int hp = 10, onemores;
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

    public Button mainMenuButton;

    public bool moving = false, facingRight, facingLeft, facingUp, facingDown;
    
    public bool canMove = true, die = false, win = false, gamePaused;
    // Use this for initialization
    void Start () {

        

        mainMenuButton.gameObject.SetActive(false);
        pauseText.text = "";

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pauseTextBox.SetActive(false);

       
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
    public void OneHiveDestroyed(int hivesdestroyed)
    {
        Debug.Log("A hive down");
        onemores += hivesdestroyed;
        if (onemores == 13)
        {
            //win game
            Debug.Log("all 13 hives down");
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

    }

    public void OnMainMenuButtonPress()
    {
        //game should quit to main menu
        SceneManager.LoadScene(3);

    }
}
