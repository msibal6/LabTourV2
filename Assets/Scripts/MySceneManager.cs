using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour
{

    public static MySceneManager instance;

    public List<Vector3> slidePos;
    public List<string> slideNames;
    public List<string> picturesTaken;
    public Vector3 playerPos;
    public Quaternion playerRot;
    public string slideDisplayed;



    // Start is called before the first frame update
    void Start()
    {

        // Maintain the same instance across the game
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
}
