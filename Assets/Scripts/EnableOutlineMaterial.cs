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
    private InteractionController player;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        myMaterials = rend.sharedMaterials;
        myMaterials[matIndex] = replaceMaterial;
        tempMaterials = rend.sharedMaterials;

        player = GameObject.Find("Player").GetComponentInChildren<InteractionController>();
            

    }

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
