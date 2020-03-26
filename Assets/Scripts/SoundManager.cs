using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioPlayer[] audios;

    private bool slideIn;
    private bool wasHolding;
    private Collider heldObject;
    private Collider hitObject;
    private InteractionController playerControl;
    private MicroscopeController microscope;



    // Start is called before the first frame update
    void Start()
    {

        // Creates static instanct of this class
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

        switch (SceneManager.GetActiveScene().name.ToString())
        {
            case "LabRoom":
                PlayLabSounds();
                break;
            case "Computer Screen":
                PlayComputerSounds();
                break;

            default:
                break;
        }

    }

    private void PlayLabSounds()
    {

        if (playerControl == null)
        {
            playerControl = FindObjectOfType<InteractionController>();
        }

        if (microscope == null)
        {
            microscope = FindObjectOfType<MicroscopeController>();
        }

        hitObject = playerControl.GetRaycastHit().collider;
        heldObject = playerControl.HeldObject;

        if (wasHolding == false && heldObject != null && heldObject.CompareTag("Slide"))
        {
            wasHolding = true;
            audios[0].Play();
        }

        // Insert Slide into Microscope slide
        //if (Input.GetMouseButtonDown(0) && wasHolding && hitObject != null
        //    && hitObject.gameObject.name == "Slide Bed")
        //{
        //    audios[1].Play();
        //    wasHolding = false;

        //}

        if (!slideIn && microscope.GetSlideName() != "")
        {
            slideIn = true;
            audios[1].Play();
        }

        if (slideIn && microscope.GetSlideName() == "")
        {
            slideIn = false;
        }

        if (wasHolding && heldObject == null)
        {
            wasHolding = false;

        }
    }

    private void PlayComputerSounds()
    {


        if (Input.GetMouseButtonDown(0))
        {
            audios[2].Play();
        }
    }


}
