using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttker : MonoBehaviour {
	public float _punchatkspeed = 5;
    public bool right, left, up, down;
    Rigidbody2D rb2d; // reference to RigidBody2d
                      // Use this for initialization
    GameObject player; //needed so the script knows where the player is
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        right = false;
        left = false;
        up = false;
        down = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            right = false;
            left = false;
            down = false;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            up = false;
            right = false;
            left = true;
            down = false;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            up = false;
            right = true;
            left = false;
            down = false;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            up = false;
            right = false;
            left = false;
            down = true;
        }

        // transform.position += transform.forward * Time.deltaTime * _punchatkspeed;
        //transform.position += new Vector3(0, _punchatkspeed * Time.deltaTime);
        if(up == true)
        {
            transform.position += new Vector3(0, _punchatkspeed * Time.deltaTime);
        }
        else if(down == true)
        {
            transform.position -= new Vector3(0, _punchatkspeed * Time.deltaTime);
        }
        else if(left == true)
        {
            transform.position -= new Vector3(_punchatkspeed * Time.deltaTime, 0);
        }
        else if(right == true)
        {
            transform.position += new Vector3(_punchatkspeed * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barriers" || other.tag == "Hives")
        {
            Destroy(gameObject);
        }


    }
}
