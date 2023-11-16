using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CarThrow : MonoBehaviour {
    public float _carSpeedBackwards = 50f;

    Rigidbody2D rb2d; // reference to RigidBody2d
    GameObject player; //needed so the script knows where the player is
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        StartCoroutine(waitsomeSeconds());

    }
	
	// Update is called once per frame
	void FixedUpdate () {

       
		
	}
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(3f);
        //rb2d.velocity = transform.position += new Vector3(_carSpeedBackwards * Time.deltaTime, 0);
        rb2d.AddForce(-transform.position * _carSpeedBackwards);
    }

   

}
