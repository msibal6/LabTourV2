using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
	public GameObject customButton;

	// Disable buttons at the beginning of the game
	void Start()
	{
		customButton.SetActive(false);	
	}

	// Cause button to appear when interacting with objects
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			customButton.SetActive(true); // this is for enable

		}
	}

	// Cause button to disappear when no longer interacting with object
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			customButton.SetActive(false);		
		}
	}
}
