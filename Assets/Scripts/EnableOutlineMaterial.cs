using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOutlineMaterial : MonoBehaviour
{
    public Material[] materials;
    private Renderer rend;
    public int matIndex;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }

    
    private void OnMouseOver()
    {
        rend.sharedMaterial = materials[1];
    }

    private void OnMouseExit()
    {
        rend.sharedMaterial = materials[0];


    }
    // Update is called once per frame
    // TODO
    // 1 Disable outline material at the start
    // 2 enable outline material when the mouse is over the object
    // 3 disble outline material when the mosue is off the object

}
