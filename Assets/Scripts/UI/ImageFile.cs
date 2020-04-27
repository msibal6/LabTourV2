using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFile : MonoBehaviour
{

    public Mutton fileIcon;
    public Image image;
    public Mutton closeMutton;


    public bool IconShowing { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CloseFile();
        HideIcon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowIcon()
    {
        fileIcon.Enable();
        IconShowing = true;
    }

    public void HideIcon()
    {
        fileIcon.Disable();
        IconShowing = false;
    }

    public void OpenFile()
    {
        transform.SetAsLastSibling();
        image.enabled = true;
        closeMutton.Enable(); 
    }

    public void CloseFile()
    {
        image.enabled = false;
        closeMutton.Disable();
    }
}
