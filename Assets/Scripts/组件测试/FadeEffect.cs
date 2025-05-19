using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Image image = null;

    /*淡入淡出设置面板*/
    [Header("淡入淡出设置")]
    //选择效果类型：是只淡入？还是只淡出？还是连续淡入淡出
    public FadeType fadeType = FadeType.FadeIn;
    //持续时间
    public float duration = 1.0f;
    //延迟多长时间进行
    public float delay = 0f;
    public bool playOnStart = true;
    //淡出后设置物体为未激活
    public bool disableAfterFadeOut = false;


    /*颜色设置面板*/
    [Header("颜色设置")]

    [Tooltip("效果开始时的颜色")]
    public Color startColor = Color.black;

    [Tooltip("当选择“Fade In Out”时生效，表示中间显示的颜色")]
    public Color targetColor = Color.white;

    [Tooltip("效果结束时的颜色")]
    public Color endColor = Color.black;

    private IEnumerator FadeIn()
    {
        


        //运行时间，用于累加
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < 1.0f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        image.color = midColor;


    }

}
