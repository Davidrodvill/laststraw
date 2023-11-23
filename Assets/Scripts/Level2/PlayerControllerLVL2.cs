using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;
public class PlayerControllerLVL2 : MonoBehaviour {

    public float _playerSpeed = 5f; //_playerSpeed is how fast the player moves
    //public float maxSpeed = 15f;
    public float hSpeed = 10f, vSpeed = 6f;
    public int hp = 10;
    public Slider healthBar;
    Animator anim;
    public Color color1Player;
    public Color color2Player;
    public SpriteRenderer sr1;

    public Text pauseText;
    Rigidbody2D rb2d; // reference to RigidBody2d

    public bool moving = false, facingRight, facingLeft, facingUp, facingDown;
    
    public bool canMove = true, die = false, win = false, gamePaused;
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            if (Input.GetAxisRaw("Vertical") > 0 && pos.y < 0.98f) //up
            {
                transform.position += new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;

                if(moving == true)
                anim.SetBool("IsMoving", true);

               //if facing up, nothing changes
               if(facingDown)
                {
                    facingDown = false;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
                
            }
            if (Input.GetAxisRaw("Vertical") < 0 && pos.y > 0.02f) //down
            {
                facingDown = true;
                transform.position -= new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;

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
            if (Input.GetAxisRaw("Horizontal") > 0 && pos.x < 0.98f) //right
            {
                Debug.Log("D key has been pressed");
                transform.position += new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;

                if (moving == true)
                anim.SetBool("IsMoving", true);

                if(!facingRight)
                {
                    facingRight = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }


                //if we were facing left, flip

            }
            if (Input.GetAxisRaw("Horizontal") < 0 && pos.x > 0.02f) //left
            {
                transform.position -= new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;


                if (facingRight)
                {
                    facingRight = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                }


            }

            //if stops moving, set StopsFlying trigger here true
            if (moving == false)
            {
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
    }

    void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        pauseText.text = "PAUSED";
        AudioListener.pause = true;
        canMove = false;

    }

    void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        pauseText.text = "";
        AudioListener.pause = false;
        canMove = true;

    }
}
