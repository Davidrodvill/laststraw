using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttker : MonoBehaviour {
	public float _punchatkspeed = 2;
    Rigidbody2D rb2d; // reference to RigidBody2d
                      // Use this for initialization
    GameObject player; //needed so the script knows where the player is
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.forward * Time.deltaTime * _punchatkspeed;

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barriers" || other.tag == "Hives")
        {
            Destroy(gameObject);
        }


    }
}
