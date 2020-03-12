using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlankeOutline : MonoBehaviour
{
    public Material replaceMaterial;

    private Renderer rend;
    private Material[] myMaterials;
    private Material[] tempMaterials;
    private InteractionController player;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        tempMaterials = rend.sharedMaterials;
        myMaterials = rend.sharedMaterials;

        for (int i = 0; i < myMaterials.Length; i++) myMaterials[i] = replaceMaterial;
            
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
