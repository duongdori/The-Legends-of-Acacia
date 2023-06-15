using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideoCtrl : MyMonoBehaviour
{
    [SerializeField] private VideoPlayer introVideo;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIntroVideo();
    }

    protected override void Awake()
    {
        base.Awake();
        
    }

    protected override void Start()
    {
        base.Start();
        introVideo.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {
        LoadNextScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        StartCoroutine(
            LevelManager.Instance.LoadSceneWithFadeEffect(1.5f, 
                LevelManager.Instance.GetCurrentSceneIndex() + 1));
    }
    private void LoadIntroVideo()
    {
        if(introVideo != null) return;
        introVideo = GetComponent<VideoPlayer>();
        Debug.LogWarning(transform.name + " LoadIntroVideo", gameObject);
    }
}
