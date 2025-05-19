using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class FadeEffect : MonoBehaviour
{
    public enum FadeType
    {
        FadeIn,
        FadeOut,
        FadeInOut
    }
    public enum FadeTarget { 
        Audio,
        TextPro,
        Sprite,
        ImageUI
    }

    /*效果对象面板*/
    [Header("效果对象设置")]
    //一开始让用户选择淡入淡出的目标对象是什么
    [Tooltip("只有被选中的“target”上的内容才会生效")]
    public FadeTarget target = FadeTarget.Audio;
    public AudioSource audioSource = null;
    public TextMeshProUGUI textMeshPro = null;
    public Renderer spriteRenderer = null;
    public UnityEngine.UI.Image image = null;

    /*淡入淡出设置面板*/
    [Header("淡入淡出设置")]
    //选择效果类型：是只淡入？还是只淡出？还是连续淡入淡出
    public FadeType fadeType = FadeType.FadeIn;
    //持续时间
    public float durationFadeIn = 1.0f;
    public float durationFadeOut = 1.0f;
    //唤醒就开始
    public bool awakeStart = true;
    //淡出后设置物体为未激活
    public bool disableAfterFadeOut = true;
    //选择淡入淡出时的停留时间
    [Tooltip("当选择“Fade In Out”时生效，表示中间停留时间")]
    public float stayTime = 1f;


    /*颜色设置面板*/
    [Header("颜色设置")]

    [Tooltip("效果开始时的颜色")]
    public Color startColor = Color.black;

    [Tooltip("效果结束时的颜色")]
    public Color endColor = Color.black;

    [Tooltip("当选择“Fade In Out”时生效，表示中间显示的颜色")]
    public Color targetColor = Color.white;


    /*音量设置面板*/
    [Header("音量设置")]

    [Tooltip("效果开始时的音量")]
    public float startVolume = 0f;

    [Tooltip("效果结束时的音量")]
    public float endVolume = 1f;

    [Tooltip("当选择“Fade In Out”时生效，表示中间显示的音量")]
    public float targetVolume = 1f;

    private void Start()
    {
        if (awakeStart)
        {
            execute();
        }
    }

    public void execute()
    {
        if(fadeType == FadeType.FadeIn)
        {
            if(target == FadeTarget.Audio)
            {
                StartCoroutine(FadeIn(audioSource));
            }
            else if(target == FadeTarget.TextPro) {
                StartCoroutine(FadeIn(textMeshPro));

            }
            else if(target == FadeTarget.Sprite)
            {
                StartCoroutine(FadeIn(spriteRenderer));

            }
            else if (target == FadeTarget.ImageUI)
            {
                StartCoroutine(FadeIn(image));

            }
        }
        else if(fadeType == FadeType.FadeOut)
        {
            if (target == FadeTarget.Audio)
            {
                StartCoroutine(FadeOut(audioSource));
            }
            else if (target == FadeTarget.TextPro)
            {
                StartCoroutine(FadeOut(textMeshPro));

            }
            else if (target == FadeTarget.Sprite)
            {
                StartCoroutine(FadeOut(spriteRenderer));

            }
            else if (target == FadeTarget.ImageUI)
            {
                StartCoroutine(FadeOut(image));

            }
        }
        else if (fadeType == FadeType.FadeInOut)
        {
            if (target == FadeTarget.Audio)
            {
                StartCoroutine(FadeInOut(audioSource));
            }
            else if (target == FadeTarget.TextPro)
            {
                StartCoroutine(FadeInOut(textMeshPro));

            }
            else if (target == FadeTarget.Sprite)
            {
                StartCoroutine(FadeInOut(spriteRenderer));

            }
            else if (target == FadeTarget.ImageUI)
            {
                StartCoroutine(FadeInOut(image));

            }
        }


    }





    private IEnumerator FadeIn(UnityEngine.UI.Image ima)
    {
        float elapsedTime = 0f;
        ima.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ima.color = endColor;
    }
    private IEnumerator FadeOut(UnityEngine.UI.Image ima)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        ima.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ima.color = endColor;

        if (disableAfterFadeOut)
        {
            ima.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(UnityEngine.UI.Image ima)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        ima.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ima.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ima.color = endColor;

        if (disableAfterFadeOut)
        {
            ima.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeIn(Renderer ren)
    {
        float elapsedTime = 0f;
        ren.material.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ren.material.color = endColor;
    }
    private IEnumerator FadeOut(Renderer ren)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        ren.material.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ren.material.color = endColor;

        if (disableAfterFadeOut)
        {
            ren.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(Renderer ren)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        ren.material.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ren.material.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        ren.material.color = endColor;

        if (disableAfterFadeOut)
        {
            ren.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeIn(TextMeshProUGUI text)
    {
        float elapsedTime = 0f;
        text.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        text.color = endColor;
    }
    private IEnumerator FadeOut(TextMeshProUGUI text)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        text.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        text.color = endColor;

        if (disableAfterFadeOut)
        {
            text.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(TextMeshProUGUI text)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        text.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        text.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        text.color = endColor;

        if (disableAfterFadeOut)
        {
            text.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeIn(AudioSource audio)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        //初始音量
        audio.volume = startVolume;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(startVolume, endVolume, elapsedTime / durationFadeIn);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        audio.volume = endVolume;
    }
    private IEnumerator FadeOut(AudioSource audio)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        //初始音量
        audio.volume = startVolume;
        while (elapsedTime < durationFadeOut)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(startVolume, endVolume, elapsedTime / durationFadeOut);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        audio.volume = endVolume;

        if (disableAfterFadeOut)
        {
            audio.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(AudioSource audio)
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        //初始音量
        audio.volume = startVolume;
        while (elapsedTime < durationFadeIn)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(startVolume, targetVolume, elapsedTime / durationFadeIn);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        audio.volume = targetVolume;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            float alpha = Mathf.Lerp(targetVolume, endVolume, elapsedTime / durationFadeOut);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //持续时间结束
        audio.volume = endVolume;

        if (disableAfterFadeOut)
        {
            audio.transform.gameObject.SetActive(false);
        }
    }

}
