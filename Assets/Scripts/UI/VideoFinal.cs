using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//在视频播放结束后背景淡出
public class VideoFinal : MonoBehaviour
{
    public VideoPlayer vp;
    //记录渐变的时间节点
    float startFadeTime;
    void Start()
    {
        //这个叫做订阅视频播放结束事件
        vp.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // 记录开始渐变的时间
        startFadeTime = Time.time;
    }
    void Update()
    {
        // 如果视频播放结束
        if (startFadeTime > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
