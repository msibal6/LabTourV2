using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{


    private GameObject holder;
    private int numSlides = 3;


    // Start is called before the first frame update
    void Start()
    {

        if (MySceneManager.instance && gameObject.name != MySceneManager.instance.slideDisplayed)
        {

            // Slide position initialization 
            // Different if slide was not in microscope
            transform.position = MySceneManager.instance.slidePos[MySceneManager.instance.slideNames.IndexOf(gameObject.name)];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsHeld()
    {
        return holder != null;
    }

    public GameObject GetHolder()
    {
        return holder;
    }

    public void SetHolder(GameObject newHolder)
    {
        holder = newHolder;
    }

    void OnDestroy()
    {

        // Saving the slide positions
        if (MySceneManager.instance.slidePos.Count < numSlides)
        {
            MySceneManager.instance.slidePos.Add(gameObject.transform.position);
            MySceneManager.instance.slideNames.Add(gameObject.name);
        }

        // Clearing the previous slide saves
        else
        {
            MySceneManager.instance.slidePos.Clear();
            MySceneManager.instance.slideNames.Clear();
            MySceneManager.instance.slidePos.Add(gameObject.transform.position);
            MySceneManager.instance.slideNames.Add(gameObject.name);
        }

    }

}
