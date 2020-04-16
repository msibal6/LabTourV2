using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mutton : MonoBehaviour
{
    public Button button;
    public Text text;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable()
    {
        button.enabled = false;
        text.enabled = false;
        image.enabled = false;
    }

    public void Enable()
    {
        button.enabled = true;
        text.enabled = true;
        image.enabled = true;
    }
}
