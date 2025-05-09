using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//在视频播放结束后背景淡出
public class VideoFinal : MonoBehaviour
{
    public VideoPlayer player;

    public AudioSource audioSource;
    public AudioSource birdAudioSource;

    //挂载视频播放器的原始图像
    public RawImage videoImage;

    //参考MaskLoad类
    public TextMeshProUGUI textMeshPro;

    Image image;

    void Start()
    {
        //添加监听器
        player.loopPointReached += CheckVideoCompletion;

        image = GetComponent<Image>();

        //不是1就是首次加载
        if (!PlayerPrefs.HasKey("video"))
        {
            //加载视频的方法
            StartCoroutine(play());
        }
        else
        {
            //不是首次加载,禁用物体,此前先让鸟叫开始
            birdAudioSource.Play();

            gameObject.transform.parent.gameObject.SetActive(false);
        }


    }
    //事件监听方法
    void CheckVideoCompletion(VideoPlayer vp)
    {
        //虽然不知道原理是什么，但是很好用（感谢豆包）
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        //刚开始不透明
        Color startColor = videoImage.color;
        startColor.a = 1f;
        videoImage.color = startColor;
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / 1f);
            startColor.a = alpha;
            videoImage.color = startColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(1f);
        player.Play();
        //准备加载文字
        string textContent = "孤阴不生，独阳不长。\r\n阴阳共生，万物乃和。\r\n万物乘变以周行，\r\n是谓平衡之枢要。";
        yield return StartCoroutine(textLoad(textContent));
        //在文字演示结束后background的渐渐消失

        //开始鸟叫
        birdAudioSource.Play();

        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //下一帧销毁有关对象
        yield return null;

        PlayerPrefs.SetInt("video", 1);
        PlayerPrefs.Save();

        gameObject.transform.parent.gameObject.SetActive(false);

    }

    public IEnumerator textLoad(string content)
    {
        //设置文本内容
        textMeshPro.text = content;
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        //播放录音
        audioSource.Play();

        //淡入0.5秒
        while (elapsedTime < 0.5f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //等待2.5秒
        yield return new WaitForSeconds(11f);
        //重置运行时间
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        textMeshPro.color = noColor;
    }
}
