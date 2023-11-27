using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.Video;

public class Beehives : MonoBehaviour {
	public int beehivehp = 4;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(beehivehp <= 0)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "AttkPunch")
		{
			beehivehp--;
			gameObject.transform.localScale += new Vector3(1, 1);
			StartCoroutine(waitsomeSeconds());
			gameObject.transform.localScale -= new Vector3(1, 1);
		}
	}
    IEnumerator waitsomeSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        
    }
}
