using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoWindow : MonoBehaviour
{
    public Image fileBackground;
    public Mutton exitMutton;
    public Mutton[] videoThumbnails;
    public Mutton videoClose;
    public VideoPlayer videoPlayer;
    public GameObject videoScreen;
    public VideoClip[] QAvideos;




    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.enabled = false;
        videoScreen.SetActive(false);
        videoClose.Disable();
        CloseVideoWindow();
    }

    public void OpenVideoWindow()
    {
        fileBackground.enabled = true;
        exitMutton.Enable();
        foreach (Mutton thumbnail in videoThumbnails)
        {
            thumbnail.Enable();
        }
    }

    public void CloseVideoWindow()
    {
        fileBackground.enabled = false;
        exitMutton.Disable();
        foreach (Mutton thumbnail in videoThumbnails)
        {
            thumbnail.Disable();
        }
    }

    public void PlayVideo(int index)
    {
        videoScreen.SetActive(true);
        videoPlayer.enabled = true;
        videoClose.Enable();
        CloseVideoWindow();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, QAvideos[index].name.ToString() + ".mp4");
        videoPlayer.Play();
        print("playing video");
    }

    public void CloseVideo()
    {
        videoScreen.SetActive(false);
        videoPlayer.enabled = false;
        videoClose.Disable();
        OpenVideoWindow();
        print("closing video");

    }

} 
