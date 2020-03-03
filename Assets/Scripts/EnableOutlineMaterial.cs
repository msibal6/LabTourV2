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


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        myMaterials = rend.sharedMaterials;
        myMaterials[matIndex] = replaceMaterial;
        tempMaterials = rend.sharedMaterials;


    }


    private void OnMouseOver()
    {
        rend.sharedMaterials = myMaterials;
      
    }

    private void OnMouseExit()
    {
        rend.sharedMaterials = tempMaterials;

    }
    // Update is called once per frame
    // TODO
    // 1 Disable outline material at the start
    // 2 enable outline material when the mouse is over the object
    // 3 disble outline material when the mosue is off the object

}
