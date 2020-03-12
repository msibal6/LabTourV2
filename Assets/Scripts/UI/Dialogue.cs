using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


// creates text where name and sentences are inputted

public class Dialogue {
	
	public string name;

	[TextArea(3, 10)]
	public string[] sentences;
}
