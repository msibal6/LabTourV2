using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateOutline : MonoBehaviour
{

    public Material replaceMaterial;

    private Renderer rend;
    private Material[] myMaterials;
    private Material[] tempMaterials;

    public InteractionController controller;
    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponentsInChildren<MeshRenderer>()[1];
        rend.enabled = true;
        tempMaterials = rend.sharedMaterials;
        myMaterials = rend.sharedMaterials;

        for (int i = 0; i < myMaterials.Length; i++) myMaterials[i] = replaceMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = controller.GetRaycastHit();
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            EnableOutline();
        }
        else if (hit.collider != null && hit.collider.gameObject == other)
        {
            EnableOutline();
        }
        else
        {
            DisableOutline();
        }
    }

    public void DisableOutline()
    {
        rend.sharedMaterials = tempMaterials;


    }

    public void EnableOutline()
    {
        rend.sharedMaterials = myMaterials; 
    }


}
