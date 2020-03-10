using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilesAppear : MonoBehaviour
{
	public Button storeButton;
	public GameObject photo;

	void Start(){
		photo = GameObject.FindGameObjectWithTag("Slide");
		storeButton.onClick.AddListener(() => MyFunction());

	} 



    // // Update is called once per frame
    void MyFunction()
    {
    	Debug.Log(" its a BUTTON");

    	photo.SetActive(true);

    }
}
