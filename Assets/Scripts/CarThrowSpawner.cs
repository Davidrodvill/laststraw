using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CarThrowSpawner : MonoBehaviour
{
    public float carSpeedBackwards;

    Rigidbody2D rb2d; // reference to RigidBody2d
    public GameObject player; //needed so the script knows where the player is
    public Transform carSpawnPoint;
    public GameObject Car1, Car2, Car3, Car4, Car5, Car6, Car7, Car8;
    public bool car1Spawn, car2Spawn, car3Spawn, car4Spawn, car5Spawn, car6Spawn, car7Spawn, car8Spawn;
    int TimeBetweenCarThrows;
    

    void Start()
    {
        player = GameObject.Find("Player");
        rb2d = GetComponent<Rigidbody2D>();
        //StartCoroutine(waitsomeSeconds());

        //car wave 1 starts
        CarWave1();

        //wait a few seconds before new wave of cars start

        //start car wave 2

        //wait a few seconds before new wave of cars start

        //start car wave 3


        carSpeedBackwards = 50;
        //TimeBetweenCarThrows = 5;
        //carSpeedBackwards = Random.Range(15, 50); //speed of which cars are thrown are randomized between these numbers
        //TimeBetweenCarThrows = Random.Range(15, 45); //interval of time when cars are thrown is also randomized.
    }

    // Update is called once per frame
    void FixedUpdate()
    {



    }
    /*
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(3f);
        //rb2d.velocity = transform.position += new Vector3(_carSpeedBackwards * Time.deltaTime, 0);
        rb2d.AddForce(-transform.position * carSpeedBackwards);
    }
    */

    //should have multiple sets of cars that get flung towards the player.

    void CarWave1()
    {

        //instantiate a set of cars at a specific point, but don't have them all instantiate at the same time.

        
        StartCoroutine(TimeBetweenCarThrow());
        

       






        /* this would move the entire CarSpawn game object towards the player, since this script is attached to it.
        //add a force so that they launch towards the player
        rb2d.AddForce(-transform.position * carSpeedBackwards);
        */


    }

    IEnumerator TimeBetweenCarThrow()
    {
        TimeBetweenCarThrows = 3;


        while(TimeBetweenCarThrows > 0)
        {
            //wait for one second
            yield return new WaitForSeconds(1);

            //tick the timer down
            TimeBetweenCarThrows--;
            Debug.Log(TimeBetweenCarThrows);

            Instantiate(Car1.gameObject, carSpawnPoint.position, Quaternion.identity);
            car1Spawn = true;

            if (TimeBetweenCarThrows <= 0)
            {
                Debug.Log("time has ended. New car should spawn now");

                
                //here is where the new cars should instantiate
                if (car1Spawn == true)
                {
                    Instantiate(Car2.gameObject, carSpawnPoint.position, Quaternion.identity);
                    car2Spawn = true;
                    car1Spawn = false;
                }
                if (car2Spawn == true)
                {
                    //StartCoroutine(TimeBetweenCarThrow());
                    Instantiate(Car3.gameObject, carSpawnPoint.position, Quaternion.identity);
                    car3Spawn = true;
                    car2Spawn = false;

                }
                if (car3Spawn == true)
                {
                    //StartCoroutine(TimeBetweenCarThrow());
                    Instantiate(Car3.gameObject, carSpawnPoint.position, Quaternion.identity);
                    car4Spawn = true;
                    car3Spawn = false;

                }
                if (car4Spawn == true)
                {
                    //StartCoroutine(TimeBetweenCarThrow());
                    Instantiate(Car4.gameObject, carSpawnPoint.position, Quaternion.identity);
                    car5Spawn = true;
                    car4Spawn = false;

                }
                if (car5Spawn == true)
                {
                    //StartCoroutine(TimeBetweenCarThrow());
                    Instantiate(Car5.gameObject, carSpawnPoint.position, Quaternion.identity);
                    car5Spawn = false;

                }
                
            }

        }
        
    }

}
