using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour
{
   
    public float _playerSpeed = 5f; //_playerSpeed is how fast the player moves
    //public float maxSpeed = 15f;
    public float hSpeed = 10f, vSpeed = 6f;
    public float speed = 15; //for thrust
    public float jump = 200;
    public float Cooldown = 5f;
    public float _nexthit = 0f;
    public int hp = 10;
    public Slider healthBar;
    public GameObject platTest1, platTest2, dialogue_box;
    Animator anim;

    public Text dialogues, playerName;

    public bool moving = false;
    public bool faceRight = true;
    public bool canMove = true, die = false, win = false;



    Rigidbody2D rb2d; // reference to RigidBody2d

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        faceRight = true;
        anim = GetComponent<Animator>();
        dialogue_box.SetActive(false);
        dialogues.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //dialogue
        if(Input.GetKey(KeyCode.T))
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

        if(other.tag == "NormalCar")
        {
            //player takes damage
            hp--;

            Debug.Log("Player has been hit by a NormalCar");
        }


        if (other.tag == "BigCar") //big cars do a bit more damage
        {
            //player takes 2 damage
            hp = (hp - 2);

            Debug.Log("Player has been hit by a BigCar. That shit hurted.");
        }
    }


}
        



    
   


