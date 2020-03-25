using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Task : MonoBehaviour
{

    public Image checkBox;
    public Image check;
    public Text taskDesc;

    // Start is called before the first frame update
    void Start()
    {
        checkBox.enabled = true;
        check.enabled = false;
        taskDesc.enabled = true;

    }

    public void CheckOff()
    {
        check.enabled = true;
    }

    public void UnCheck()
    {
        check.enabled = false;

    }
}
