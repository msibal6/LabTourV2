using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObject : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit ourObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out ourObject, 3.5f))
        {
            selectedObject = ourObject.transform.gameObject.name;
            internalObject = ourObject.transform.gameObject.name;
        }
    }
}
