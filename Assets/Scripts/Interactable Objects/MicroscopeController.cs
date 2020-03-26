using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeController : MonoBehaviour
{



    public Transform placePoint;
    public Transform entryPoint;

    private bool inPlace;
    private bool readyToEnter;
    private GameObject placedSlide;




    // Start is called before the first frame update
    void Start()
    {
        if (MySceneManager.instance)
        {
            if (MySceneManager.instance.slideDisplayed != "")
            {
                //Place(GameObject.Find(MySceneManager.instance.slideDisplayed));

                GameObject tempSlide = GameObject.Find(MySceneManager.instance.slideDisplayed);
                placedSlide = tempSlide;
                placedSlide.transform.position = placePoint.transform.position;
                placedSlide.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                inPlace = true;
                readyToEnter = true;
                SlideController tempSlideControl = placedSlide.gameObject.GetComponent<SlideController>();
                tempSlideControl.SetHolder(gameObject);
                MySceneManager.instance.slideDisplayed = placedSlide.gameObject.name;
            }
        }

    }

    private void FixedUpdate()
    {
        if (placedSlide != null)
        {
            if (!inPlace && !readyToEnter)
            {
                placedSlide.transform.position = Vector3.Lerp(placedSlide.transform.position, entryPoint.transform.position, 0.4f);
            }
            else if (!inPlace && readyToEnter)
            {
                placedSlide.transform.position = Vector3.Lerp(placedSlide.transform.position, placePoint.transform.position, 0.4f);
            }
            else
            {
                placedSlide.transform.position = placePoint.transform.position;
                placedSlide.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
            }
        }
    }


    public void Place(GameObject slideToPlace)
    {

        placedSlide = slideToPlace;

        StartCoroutine(MoveSlide());
        //while (!inPlace)
        //{
        //    placedSlide.transform.position = Vector3.MoveTowards(placedSlide.transform.position, placePoint.transform.position, 0.05f);
        //}
        //placedSlide.transform.position = placePoint.transform.position;


        SlideController tempSlide = placedSlide.gameObject.GetComponent<SlideController>();
        tempSlide.SetHolder(gameObject);
        MySceneManager.instance.slideDisplayed = placedSlide.gameObject.name;

    }

    public void Release()
    {
        placedSlide = null;
        inPlace = false;
        readyToEnter = false;
        MySceneManager.instance.slideDisplayed = "";
    }

    public bool ContainSlide()
    {
        return (placedSlide != null);
    }

    public string GetSlideName()
    {
        if (placedSlide != null)
        {
            return placedSlide.gameObject.name;
        }
        return "";
    }

    IEnumerator MoveSlide()
    {


        yield return new WaitForSeconds(.09375f);
        readyToEnter = true;
        yield return new WaitForSeconds(.01f);
        inPlace = true;


    }



}
