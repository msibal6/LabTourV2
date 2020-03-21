using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

        // Initializes using instance after first switch to LabRoom scene
        if (MySceneManager.instance)
        {
            gameObject.transform.position = MySceneManager.instance.playerPos;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        _ = controller.Move(moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")));
    }

    private void OnDestroy()
    {
        MySceneManager.instance.playerPos = transform.position;
        Cursor.lockState = CursorLockMode.None;
    }
}
