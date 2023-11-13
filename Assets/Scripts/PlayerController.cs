using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour {
    public float _playerSpeed = 5f; //_playerSpeed is how fast the palyer moves, _playerRotationSpeed is how fast the player can turn.
    public float speed = 15; //for thrust
    public float jump = 200;
    public float Cooldown = 5f;
    public float _nexthit = 0f;
    public GameObject platTest1, platTest2;


    public bool moving = false;
    public bool faceRight;
    public bool canMove = true;
    private bool cool = false;


    Rigidbody2D rb2d; // reference to RigidBody2d

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        faceRight = true;
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            moving = false;
        }

        if (canMove)
        {
            //Get the player Position on screen (0-1 in x and y)
            Vector3 pos = Camera.main.WorldToViewportPoint(
                transform.position);

           
            if (Input.GetAxisRaw("Horizontal") > 0 &&
                pos.x < 0.96f) //right
            {
                transform.position += new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
                faceRight = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 &&
               pos.x > 0.1f) //left
            {
                transform.position -= new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
                faceRight = false;

            }
        }
        
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
            _nexthit = Time.time + Cooldown;
       }

        //Jump (= SPACE) when on a platform, not air
        bool canJump = true;
        //brandon was here :3
        if (Physics2D.OverlapArea(platTest1.transform.position, platTest2.transform.position))
            canJump = (Physics2D.OverlapArea(platTest1.transform.position, platTest2.transform.position).tag == "Platform");
        else canJump = false;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(new Vector3(0, jump));
        }
    }
   

}
