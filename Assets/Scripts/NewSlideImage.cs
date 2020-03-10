using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSlideImage : MonoBehaviour
{
	public Sprite slide1, slide2, slide3;

    // Update is called once per frame
    void Update()
    {
    	if (MySceneManager.instance.slideDisplayed == "brain slide (1)")
        {
            // Debug.Log("test1");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slide1;
        }
            
        else if (MySceneManager.instance.slideDisplayed == "brain slide (2)"){
           	this.gameObject.GetComponent<SpriteRenderer>().sprite = slide2;
            // Debug.Log("test2"); 
        }	
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slide3;
            // Debug.Log("its an empty slide!!");

        }
    }
}
