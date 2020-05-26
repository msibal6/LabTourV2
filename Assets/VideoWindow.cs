using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoWindow : MonoBehaviour
{
    public Image fileBackground;
    public Mutton exitMutton;
    public Mutton videoClose;
    public VideoPlayer videoPlayer;
    public GameObject videoScreen;
    public VideoClip[] QAvideos;




    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.enabled = false;
        videoScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenVideoWindow()
    {

    }

    public void CloseVideoWindow()
    {
        // close the video window
    }

    public void PlayVideo(int index)
    {
        videoScreen.SetActive(true);
        videoPlayer.enabled = true;

        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, QAvideos[index].name.ToString() + ".mp4");
        videoPlayer.Play();
        print("playing video");
    }

    public void CloseVideo()
    {
        // close currently playing video 
    }
} 
