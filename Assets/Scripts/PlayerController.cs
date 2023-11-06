using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float _playerSpeed = 5f;

    public bool canMove = true;
    public bool moving = false;

    public Vector3[] _playerPositions = { new Vector3(0, 0, 0), new Vector3(50, 40, 0) };

    Animator anim;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (moving)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            moving = false;
        }

        if(canMove)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(
                transform.position);
            if (Input.GetAxisRaw("Vertical") > 0 &&
                    pos.y < 0.96f)//up
            {
                transform.position += new Vector3(
                    0, _playerSpeed * Time.deltaTime);
                moving = true;
            }
            if (Input.GetAxisRaw("Vertical") < 0 &&
                pos.y > 0.11f) //down
            {
                transform.position -= new Vector3(
                    0, _playerSpeed * Time.deltaTime);
                moving = true;
            }
            if (Input.GetAxisRaw("Horizontal") > 0 &&
                pos.x < 0.96f) //right
            {
                transform.position += new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 &&
               pos.x > 0.1f) //left
            {
                transform.position -= new Vector3(
                    _playerSpeed * Time.deltaTime, 0);
                moving = true;
            }

        }
    }
}
