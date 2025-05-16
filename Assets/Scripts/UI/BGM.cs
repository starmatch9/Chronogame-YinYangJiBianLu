using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BGM : MonoBehaviour
{
    //参考BGMmanager脚本
    public AudioSource audioSource;
    public VideoPlayer player;

    void Start()
    {
        //添加监听器
        player.loopPointReached += CheckVideoCompletion;

        //不是1就是首次加载
        if (PlayerPrefs.HasKey("video"))
        {
            StartCoroutine(load());
        }

    }
    //事件监听方法
    void CheckVideoCompletion(VideoPlayer vp)
    {
        //虽然不知道原理是什么，但是很好用
        StartCoroutine(load());
    }
    //淡入
    private IEnumerator load()
    {
        //设置开始音量为0
        audioSource.volume = 0f;
        audioSource.Play();
        //累计时间
        float elapsed = 0;
        while (elapsed < 5f)
        {
            audioSource.volume = Mathf.Lerp(0f, 0.05f, elapsed / 5f);
            //增量
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0.05f;
    }
    //淡出
    private IEnumerator fade()
    {
        //定为标准的1
        audioSource.volume = 0.05f;
        //累计时间
        float elapsed = 0;
        while (elapsed < 1f)
        {
            audioSource.volume = Mathf.Lerp(0.05f, 0f, elapsed / 1f);
            //增量
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0f;
    }
}
