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
    public bool isOutlined;


    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponentsInChildren<MeshRenderer>()[1];
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
