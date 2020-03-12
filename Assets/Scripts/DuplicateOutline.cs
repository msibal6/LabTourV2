using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateOutline : MonoBehaviour
{

    public InteractionController controller;
    public GameObject  outliner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = controller.GetRaycastHit();
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            print("sending outline");
            outliner.SendMessage("EnableOutline");
        }
        else
        {
            outliner.SendMessage("DisableOutline");
        }
    }
}
