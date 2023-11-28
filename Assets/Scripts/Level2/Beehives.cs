﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;
public class Beehives : MonoBehaviour
{
    public int beehivehp = 20;
    public Slider healthBar;
    public Transform healthbarPos;
    public Color color1Player; //should be normal
    public Color color2Player; //should be red (switch to this color after enemy gets hit)
    public SpriteRenderer sr1;

    // Use this for initialization
    void Start()
    {
        GameObject hb = Instantiate(healthBar.gameObject);
        //put the healthbar on the canvas
        hb.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar = hb.GetComponent<Slider>();
    }

    void Update()
    {
        //update heath bar
        healthBar.transform.position = Camera.main.WorldToScreenPoint(healthbarPos.transform.position);
        healthBar.value = beehivehp;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (beehivehp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.tag == "AttkPunch")
        {
            beehivehp--;
            gameObject.transform.localScale += new Vector3(1, 1);
            StartCoroutine(waitsomeSeconds());
            gameObject.transform.localScale -= new Vector3(1, 1);
        }
        */
    }
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(0.5f);

    }


    public void TakeDamage(int damage)
    {
        Debug.Log("Hive has been attacked");
        beehivehp -= damage;

        StartCoroutine(BeehiveHit());

        if(beehivehp <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar.gameObject);
        }

    }

    IEnumerator BeehiveHit()
    {
        sr1.color = color2Player;
        yield return new WaitForSeconds(.5f);
        sr1.color = color1Player;

    }

}