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

    public bool moving = false;
    
    public bool canMove = true, die = false, win = false, gamePaused;
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
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
        }

        

        if (canMove)
        {
            //4 directional movement (top-down)
            if (Input.GetAxisRaw("Vertical") > 0 && pos.y < 0.98f) //up
            {
                transform.position += new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;
               

               
                
            }
            if (Input.GetAxisRaw("Vertical") < 0 && pos.y > 0.02f) //down
            {
                transform.position -= new Vector3(0, vSpeed * Time.deltaTime);
                moving = true;
               

                //if stops moving, set StopsFlying trigger here true

            }
            if (Input.GetAxisRaw("Horizontal") > 0 && pos.x < 0.98f) //right
            {
                Debug.Log("D key has been pressed");
                transform.position += new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;
               

               


                //if we were facing left, flip
                
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && pos.x > 0.02f) //left
            {
                transform.position -= new Vector3(hSpeed * Time.deltaTime, 0);
                moving = true;
                

               

               
            }

            //if stops moving, set StopsFlying trigger here true
            if (moving == false)
            {
                
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
