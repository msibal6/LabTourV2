using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{

    public GameObject ui;

    PopupMessage popupMessage;
    GameObject gameController;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        popupMessage = gameController.GetComponent<PopupMessage>();
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
    public void Close()
    {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
    //You need to have Folder Resources/InvenotryItems
    public Texture TakeInvenotryCollecition(string LoadCollectionsToInventory)
    {
        Texture loadedGO = Resources.Load("InvenotryItems/" + LoadCollectionsToInventory, typeof(Texture)) as Texture;
        return loadedGO;
    }

    public void Open()
    {
        ui.SetActive(true);

        ui.GetComponentsInChildren<RawImage>()[1].enabled = false;
        ui.GetComponentsInChildren<Text>()[0].enabled = false;

        ui.GetComponentsInChildren<RawImage>()[2].enabled = false;
        ui.GetComponentsInChildren<Text>()[1].enabled = false;

        if (MySceneManager.instance.picturesTaken.Contains("Control Blue"))
        {
            ui.GetComponentsInChildren<RawImage>()[1].enabled = true;
            ui.GetComponentsInChildren<Text>()[0].enabled = true;

        }

        if (MySceneManager.instance.picturesTaken.Contains("Stress Blue"))
        {
            ui.GetComponentsInChildren<RawImage>()[2].enabled = true;
            ui.GetComponentsInChildren<Text>()[1].enabled = true;
        }

    }


}