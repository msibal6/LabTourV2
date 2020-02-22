
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
  

    public Transform holdPoint;
    public float horizontalPan = 2.5f;
    public float verticaPan = 2.5f;
    public float moveSpeed = 2.0f; 
    
    private float yaw;
    private float pitch;

    public float maxInteractionDistance;

    public float maxVertical = 30f;
    public float maxHorizontal = 30f;

    private bool grabbing;
    private Collider heldObject;


    


    



    // Start is called before the first frame update
    void Start()
    {

        // Initializes using instance after first switch to LabRoom scene
        if (MySceneManager.instance)
        {
            gameObject.transform.position = MySceneManager.instance.playerPos;
        }

        //SceneManager.sceneUnloaded += PlayerCleanUp;


        // TODO Cursor visibility needs fixing

        //Cursor.visible = true;
        //Cursor.SetCursor(Texture2D.blackTexture, new Vector2(Screen.width / 2, Screen.height / 2), CursorMode.Auto);

        Cursor.lockState = CursorLockMode.Locked;

        //Cursor.SetCursor(Texture2D.blackTexture, Vector2.zero, CursorMode.Auto);


    }

    // Update is called once per frame
    void Update()
    {
        
        yaw += horizontalPan * Input.GetAxisRaw("Mouse X");
        pitch -= verticaPan * Input.GetAxisRaw("Mouse Y");
        transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.eulerAngles = new Vector3(Mathf.Clamp(pitch,-maxVertical,maxVertical), Mathf.Clamp(yaw,-maxHorizontal,maxHorizontal));
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);


        // Looking to determine if there is something to interact with
        // THIS IS AN INTERACTION ARRAY
        Physics.Raycast(ray, out RaycastHit hit, maxInteractionDistance);


        // You try to grab here
        if (Input.GetMouseButtonDown(0))
        {
            // TODO Add all grabbin cases i.e grabbing and you want to switch with something and etc
            // TODO Reimplement grabbing cases
            // We can be looking at microscope
            //              slide
            //              monitor
            //              nothing

            // We are not grabbing anything currently
            if (!grabbing)
            {
                // Looking at an object you can grab
                if (hit.collider.gameObject.layer == 8)
                {
                    heldObject = hit.collider;
                    grabbing = true;
                    // Object is a slide
                    if (heldObject.gameObject.CompareTag("Slide"))
                    {
                        PickUpSlide(heldObject);
                    }
                    // Object is a flask or just not a slide
                }
                // TODO Grabbing across scenes
                // Looking at something you cannot grab ie the Microscope or Monitor
            
                // Looking at none of above


            }
            else // You are grabbing
            {
                
                // Looking at another object you can grab
                if (hit.collider.gameObject.layer == 8)
                {
                    Release();
                    heldObject = hit.collider;
                    grabbing = true;
                    // Object is a slide
                    if (heldObject.gameObject.CompareTag("Slide"))
                    {
                        PickUpSlide(heldObject);
                    }
                    // Object is a flask or just not a slide
                }
                else if (heldObject.gameObject.CompareTag("Slide") && hit.collider.gameObject.name == "Slide Bed")
                {
                    MicroscopeController tempMicroscopeController = hit.collider.transform.parent.gameObject.GetComponent<MicroscopeController>();
                    if (!tempMicroscopeController.ContainSlide())
                    {
                        tempMicroscopeController.Place(heldObject.gameObject);
                        heldObject.gameObject.GetComponent<SlideController>().SetHolder(tempMicroscopeController.gameObject);
                        Release();
                    }
                    else
                    {
                        // Placeholder for tooltip that tells there is a slide in the microscope
                        Debug.Log("Theres already A slide in the microscope");

                    }

                }
                // Looking at none of above
                else
                {
                    Release();
                }


            }
            if (hit.collider.gameObject.name == "Monitor")
            {
                MySceneManager.instance.SwitchScene("Computer Screen");
            }
            else if (hit.collider.gameObject.name == "Looking part")
            {
                MySceneManager.instance.SwitchScene("NewMicroscopeView");

            }

            //  1st Version Grabbing implementation 
            // Nothing in your hand and you're trying to grab something
            //if (!grabbing && hit.collider != null && hit.collider.gameObject.layer == 8)
            //{

            //    heldObject = hit.collider;
            //    grabbing = true;
            //    Debug.Log(hit.collider.gameObject.layer);

            //    // Check if we are grabbing a slide

            //    if (heldObject.gameObject.CompareTag("Slide"))
            //    {
            //        SlideController tempSlide = heldObject.gameObject.GetComponent<SlideController>();
            //        // Is the slide in the microscope
            //        if (tempSlide.IsHeld())
            //        {
            //            // Release the slide from the microscope
            //            MicroscopeController tempMicro = tempSlide.GetHolder().GetComponent<MicroscopeController>();
            //            Debug.Log("releasing slide");
            //            tempMicro.Release();
            //            tempSlide.SetHolder(gameObject);
            //        }
            //        else
            //        {
            //            tempSlide.SetHolder(gameObject);


            //        }
            //    }
            //}

            //// Inserting  and releasing Slide Bed if we are grabbing it
            //else if (heldObject != null && heldObject.gameObject.CompareTag("Slide") && hit.collider != null && hit.collider.gameObject.name == "Slide Bed")
            //{
            //MicroscopeController tempMicroscopeController = hit.collider.transform.parent.gameObject.GetComponent<MicroscopeController>();

            //if (!tempMicroscopeController.ContainSlide())
            //{
            //    tempMicroscopeController.Place(heldObject.gameObject);
            //    heldObject.gameObject.GetComponent<SlideController>().SetHolder(tempMicroscopeController.gameObject);
            //    Release();
            //}
            //else
            //{
            //    // Placeholder for tooltip that tells there is a slide in the microscope
            //    Debug.Log("Theres already A slide in the microscope");

            //}
            //}
            //// You are releasing it into nothing i.e dropping it
            //else
            //{
            //    Release();
            //}

            //if (hit.collider != null && hit.collider.gameObject.name == "Looking part")
            //{
            //    MySceneManager.instance.SwitchScene("NewMicroscopeView");

            //}
            //else if (hit.collider != null && hit.collider.gameObject.name == "Monitor")
            //{
            //    MySceneManager.instance.SwitchScene("Computer Screen");

            //}
        }

        // Object Tracking for when you are holding it
        // Goes faster wehn you are moving to prevent jitter
        if (grabbing)
        {
            bool isMoving = System.Math.Abs(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical")) > 0;
            heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, holdPoint.transform.position, isMoving ? .08f : 0.05f);

        }
    }

    private void PickUpSlide(Collider slide)
    {
        SlideController tempSlide = slide.gameObject.GetComponent<SlideController>();
        // Is the slide in the microscope
        if (tempSlide.IsHeld())
        {
            // Release the slide from the microscope
            MicroscopeController tempMicro = tempSlide.GetHolder().GetComponent<MicroscopeController>();
            tempMicro.Release();
            tempSlide.SetHolder(gameObject);
        }
        else
        {
            ;
        }
    }

    private void Release()
    {
        grabbing = false;
        heldObject = null;
    }

    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }




    void OnDestroy()
    {
        MySceneManager.instance.playerPos = transform.position;
        Cursor.lockState = CursorLockMode.None;

    }

    //private void PlayerCleanUp(Scene current)
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //}

}
