using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour
{
    public Transform holdPoint;

    public float mouseSens;
    public float maxInteractionDistance;
    public float maxVertical = 30f;
    public float maxHorizontal = 30f;

    //private Collider heldObject;

    private float yaw;
    private float pitch;
    private bool grabbing;
    private Collider heldObject;

    private RaycastHit hit;

    public Collider HeldObject { get => heldObject; private set => heldObject = value; }

    void Start()
    {

        // Initializes using instance after first switch to LabRoom scene
        if (MySceneManager.instance)
        {
            transform.localRotation = MySceneManager.instance.playerRot;
        }


    }
    // Update is called once per frame
    void Update()
    {
        yaw += mouseSens * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= mouseSens * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -maxVertical, maxVertical), Mathf.Clamp(yaw, -maxHorizontal, maxHorizontal));
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(pitch, -maxVertical, maxVertical), Mathf.Clamp(yaw, -maxHorizontal, maxHorizontal), 0f);

    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        // Looking to determine if there is something to interact with
        Physics.Raycast(ray, out hit, maxInteractionDistance);

        // You try to grab here
        if (Input.GetMouseButtonDown(0))
        {

            // We are not grabbing anything currently
            if (!grabbing)
            {

                // Looking at an object you can grab
                if (hit.collider != null && hit.collider.gameObject.layer == 8)
                {
                    HeldObject = hit.collider;
                    grabbing = true;

                    // Object is a slide
                    if (HeldObject.gameObject.CompareTag("Slide"))
                    {
                        PickUpSlide(HeldObject);
                    }
                }
            }
            else // You are grabbing
            {

                // Looking at another object you can grab
                if (hit.collider == null)
                {
                    if (HeldObject.gameObject.CompareTag("Slide"))
                    {
                        HeldObject.gameObject.GetComponent<SlideController>().SetHolder(null);
                    }

                    Release();
                }
                else if (HeldObject.gameObject.CompareTag("Slide") && hit.collider.gameObject.name == "Slide Bed")
                {
                    MicroscopeController tempMicroscopeController = hit.collider.transform.parent.gameObject.GetComponent<MicroscopeController>();
                    if (!tempMicroscopeController.ContainSlide())
                    {
                        tempMicroscopeController.Place(HeldObject.gameObject);
                        HeldObject.gameObject.GetComponent<SlideController>().SetHolder(tempMicroscopeController.gameObject);
                        Release();
                    }
                    else
                    {
                        // TODO 
                        // Placeholder for tooltip that tells there is a slide in the microscope
                        Debug.Log("Theres already A slide in the microscope");
                    }
                }

                // Looking at none of above
                else if (hit.collider.gameObject.layer == 8)
                {
                    Release();
                    HeldObject = hit.collider;
                    grabbing = true;

                    // Object is a slide
                    if (HeldObject.gameObject.CompareTag("Slide"))
                    {

                        PickUpSlide(HeldObject);
                    }
                }
                else
                {
                    Release();
                }
            }

            if (hit.collider != null && hit.collider.gameObject.name == "Monitor")
            {
                var manager = FindObjectOfType<DialogueManager>();
                manager.transform.parent = null;
                print(manager.transform.parent);
                SceneManager.LoadScene("Computer Screen");
            }
            else if (hit.collider != null && (hit.collider.gameObject.name == "Looking part"
                || hit.collider.gameObject.name == "Looking part 1"))
            {
                SceneManager.LoadScene("NewMicroscopeView");
            }
            else
            {
                ;
            }
        }

        // Object Tracking for when you are holding it
        // Goes faster wehn you are moving to prevent jitter
        if (grabbing)
        {
            bool isMoving = System.Math.Abs(Input.GetAxisRaw("Horizontal") + Input.GetAxisRaw("Vertical")) > 0;
            HeldObject.transform.position = Vector3.MoveTowards(HeldObject.transform.position, holdPoint.transform.position, isMoving ? .08f : 0.05f);
        }
    }

    public RaycastHit GetRaycastHit()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        //Physics.Raycast(ray, out RaycastHit hit, maxInteractionDistance);
        return hit;
    }

    public Collider GetHeldObject()
    {
        return HeldObject;

    }

    private void PickUpSlide(Collider slide)
    {
        SlideController tempSlide = slide.gameObject.GetComponent<SlideController>();

        // Is the slide in the microscope
        if (tempSlide.GetHolder() != null && tempSlide.GetHolder().name == "Microscope")
        {

            // Release the slide from the microscope
            MicroscopeController tempMicro = tempSlide.GetHolder().GetComponent<MicroscopeController>();
            tempMicro.Release();
            tempSlide.SetHolder(gameObject);
        }
    }

    private void Release()
    {
        grabbing = false;
        HeldObject = null;
    }

    void OnDrawGizmos()
    {

        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }

    private void OnDestroy()
    {
        MySceneManager.instance.playerRot = transform.localRotation;
    }
}
