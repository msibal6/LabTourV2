using UnityEngine;
using UnityEngine.UI;


public class TransparencyImages : MonoBehaviour
 {
     public RawImage rawImg = null;
     public byte alpha = 255;
     public void Update ()
     {
         Color color;
         color = new Color32(0,0,0,alpha);
         if(rawImg)rawImg.color = new Color(rawImg.color.r,rawImg.color.g,rawImg.color.b,color.a);
     }
 }