using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeImage : MonoBehaviour
{
	// public static class TakeImage;

	public static Button PictureTaken;

    void Start()
    {
        Button btn = PictureTaken.GetComponent<Button>();
        btn.onClick.AddListener(TakePic);
    }


    public void TakePic()
    {

        Debug.Log("Hello.");

    }
}
