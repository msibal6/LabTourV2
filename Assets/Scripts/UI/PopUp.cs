using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUp : MonoBehaviour
{

    public Image image;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        text.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsShowing()
    {
        return (image.enabled && text.enabled);
    }
    public void Display()
    {
        image.enabled = true;
        text.enabled = true;

    }

    public void Close()
    {
        image.enabled = false;
        text.enabled = false;
    }
}
