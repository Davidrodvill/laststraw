using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {

	public GameObject blackoutSquare;
	
	// Update is called once per frame
	void Update () {
		


	}

	public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
	{
		
		Color objectColor = blackoutSquare.GetComponent<Image>().color;
		float fadeAmount;

		if(fadeToBlack)
		{
			while (blackoutSquare.GetComponent<Image>().color.a < 1)
			{

				fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

				objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
				blackoutSquare.GetComponent<Image>().color = objectColor;
				yield return null;
			}
			
		}
		else
		{

			while (blackoutSquare.GetComponent<Image>().color.a > 0)
			{
				fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

				objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
				blackoutSquare.GetComponent<Image>().color = objectColor;
				yield return null;

			}

		}
		
	}

}
