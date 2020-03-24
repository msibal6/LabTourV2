using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{

    public GameObject ui;

    PopupMessage popupMessage;
    GameObject gameController;

    private PopUp[] picturesTaken;
    // Use this for initialization
    void Start()
    {

        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
        picturesTaken = ui.GetComponentsInChildren<PopUp>();

    }

    // private void OnMouseDown()
    // {

    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Debug.Log("Pressed left click.");
    //         ui.SetActive(true);

    //     } 

    // }

    // // Update is called once per frame
    // void Update () {
    // 	if (Input.GetMouseButtonDown(1))
    //     {
    //         ui.SetActive(false);
    //     }
    // }

    //public void Open(string inventoryStuffName, string message)
    //{
    //    ui.SetActive(!ui.activeSelf);

    //    if (ui.activeSelf)
    //    {
    //        if (!string.IsNullOrEmpty(inventoryStuffName))
    //        {
    //            var texture = TakeInvenotryCollecition(inventoryStuffName);
    //            RawImage rawImage = ui.gameObject.GetComponentInChildren<RawImage>();
    //            rawImage.texture = texture;
    //        }
    //        if (!string.IsNullOrEmpty(message))
    //        {
    //            Text textObject = ui.gameObject.GetComponentInChildren<Text>();
    //            textObject.text = message;
    //        }
    //        Time.timeScale = 0f;
    //    }
    //}

    // 
    public void Close()
    {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
    //You need to have Folder Resources/InvenotryItems
    public Texture TakeInvenotryCollection(string LoadCollectionsToInventory)
    {
        Texture loadedGO = Resources.Load("InvenotryItems/" + LoadCollectionsToInventory, typeof(Texture)) as Texture;
        return loadedGO;
    }

    public void Open()
    {
        // TODO make a whole window  class
        // Make a class for files folder
        ui.SetActive(true);
        if (MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            picturesTaken[0].Display();



        }



        // TODO HIGH
        // Replace all images taken with the correct PopUps



    }


}