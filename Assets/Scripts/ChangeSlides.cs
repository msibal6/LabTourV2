using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSlides : MonoBehaviour
{
	public Sprite[] s1;
	public Button b1; 

	int count = 0;

	void Awake()
	{
		s1 = Resources.LoadAll<Sprite>("Sprites");
	}

	public void On_Click_Button(){
		count++;

		if (count== s1.Length) {
			count = 0;
			}
		b1.image.sprite = s1[0];
        if (MySceneManager.instance.slideDisplayed == "brain slide")
        {
			b1.image.sprite = s1[0];

		}
        else
        {
			b1.image.sprite = s1[1];

        }

	}
}
