using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoController : MonoBehaviour
{
    public VideoPlayer usageVideo;    //用法视频
    public VideoPlayer patternVideo;    //句法视频

    public Button playButton;   //播放按钮
    public Button leftButton;
    public Button rightButton;
    public Slider videoSlider;  //进度条
    private bool isPlaying;
    private videoNames nowPlayingName;  //正在播放视频的名字
    private VideoPlayer nowPlayingVideo;    //正在播放的视频
    private bool isPressedSliderButton; //是否正在按下滑动条

    void Start()
    {
        usageVideo.gameObject.SetActive(true);
        patternVideo.gameObject.SetActive(false);
        nowPlayingVideo=usageVideo;
        nowPlayingName=videoNames.usageVideo;
        isPlaying=false;
        videoSlider.onValueChanged.AddListener(UpadateSliderValue); //滑动条事件监听
        videoSlider.value=0f;
    }


    private void Update()
    {
        
    }

    public void PlayButton()
    {
        if(!isPlaying)
        {
            nowPlayingVideo.Play();
            isPlaying=true;
            // Debug.Log("播："+isPlaying);
        }
        else
        {
            nowPlayingVideo.Pause();
            isPlaying=false;
            // Debug.Log("停："+isPlaying);
        }
    }

    public void SwitchVideoButton()
    {
        switch(nowPlayingName)
        {
            case videoNames.usageVideo:
                usageVideo.gameObject.SetActive(false);
                patternVideo.gameObject.SetActive(true);
                nowPlayingName=videoNames.patternVideo;
                nowPlayingVideo=patternVideo;
                isPlaying=false;
                videoSlider.value=0;
                break;
            case videoNames.patternVideo:
                patternVideo.gameObject.SetActive(false);
                usageVideo.gameObject.SetActive(true);
                nowPlayingName=videoNames.usageVideo;
                nowPlayingVideo=usageVideo;
                isPlaying=false;
                videoSlider.value=0;
                break;
            default :break;
        }
    }
    
    //滑动条事件触发后执行方法
    private void UpadateSliderValue(float value)
    {
        nowPlayingVideo.time=value*nowPlayingVideo.length;
    }
}
