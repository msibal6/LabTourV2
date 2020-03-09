using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOutlineMaterial : MonoBehaviour
{
    public Material replaceMaterial;
    public int matIndex;

    private Renderer rend;
    private Material[] myMaterials;
    private Material[] tempMaterials;
    private CameraController player;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        myMaterials = rend.sharedMaterials;
        myMaterials[matIndex] = replaceMaterial;
        tempMaterials = rend.sharedMaterials;

        player = GameObject.Find("Player Camera").GetComponent<CameraController>();
            

    }

    

    //private void OnMouseOver()
    //{
    //    rend.sharedMaterials = myMaterials;

    //}

    //private void OnMouseExit()
    //{
    //    rend.sharedMaterials = tempMaterials;

    //}
    private void Update()
    {
        RaycastHit hit = player.GetRaycastHit();
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            rend.sharedMaterials = myMaterials;

        }
        else
        {
            rend.sharedMaterials = tempMaterials;
        }
        
    }


}
