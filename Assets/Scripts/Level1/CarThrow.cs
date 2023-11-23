using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CarThrow : MonoBehaviour {
    //public float _carSpeedBackwards = 50f;
    public float _carSpeedBackwards;
    float rotateSpeed;

    Rigidbody2D rb2d; // reference to RigidBody2d
    GameObject player; //needed so the script knows where the player is
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();

        _carSpeedBackwards = Random.Range(50, 85); //speed of which cars are thrown are randomized between these numbers
        rotateSpeed = Random.Range(0f, 35f);
    }

    // Update is called once per frame
    void FixedUpdate () {

        StartCoroutine(waitsomeSeconds());

        transform.position -= new Vector3(_carSpeedBackwards * Time.deltaTime, 0);

        transform.Rotate(new Vector3(0, 0, 45 * rotateSpeed * Time.deltaTime));

        /*
        //clean-up: if enough off camera, delete self
        Vector3 screenpos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenpos.x < -181.6f)
        {
            Destroy(gameObject);
        }
        */
    }
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(10f);
        //rb2d.AddForce(-transform.position * _carSpeedBackwards);

       

        //yield return new WaitForSeconds(3f);
        //rb2d.velocity = transform.position += new Vector3(_carSpeedBackwards * Time.deltaTime, 0);
        //rb2d.AddForce(-transform.position * _carSpeedBackwards);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CarDestroy")
        {
            Destroy(gameObject);
        }


    }


}
