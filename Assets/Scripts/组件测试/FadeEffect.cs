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

    /*Ч���������*/
    [Header("Ч����������")]
    //һ��ʼ���û�ѡ���뵭����Ŀ�������ʲô
    [Tooltip("ֻ�б�ѡ�еġ�target���ϵ����ݲŻ���Ч")]
    public FadeTarget target = FadeTarget.Audio;
    public AudioSource audioSource = null;
    public TextMeshProUGUI textMeshPro = null;
    public Renderer spriteRenderer = null;
    public UnityEngine.UI.Image image = null;

    /*���뵭���������*/
    [Header("���뵭������")]
    //ѡ��Ч�����ͣ���ֻ���룿����ֻ�����������������뵭��
    public FadeType fadeType = FadeType.FadeIn;
    //����ʱ��
    public float durationFadeIn = 1.0f;
    public float durationFadeOut = 1.0f;
    //���ѾͿ�ʼ
    public bool awakeStart = true;
    //��������������Ϊδ����
    public bool disableAfterFadeOut = true;
    //ѡ���뵭��ʱ��ͣ��ʱ��
    [Tooltip("��ѡ��Fade In Out��ʱ��Ч����ʾ�м�ͣ��ʱ��")]
    public float stayTime = 1f;


    /*��ɫ�������*/
    [Header("��ɫ����")]

    [Tooltip("Ч����ʼʱ����ɫ")]
    public Color startColor = Color.black;

    [Tooltip("Ч������ʱ����ɫ")]
    public Color endColor = Color.black;

    [Tooltip("��ѡ��Fade In Out��ʱ��Ч����ʾ�м���ʾ����ɫ")]
    public Color targetColor = Color.white;


    /*�����������*/
    [Header("��������")]

    [Tooltip("Ч����ʼʱ������")]
    public float startVolume = 0f;

    [Tooltip("Ч������ʱ������")]
    public float endVolume = 1f;

    [Tooltip("��ѡ��Fade In Out��ʱ��Ч����ʾ�м���ʾ������")]
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
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ima.color = endColor;
    }
    private IEnumerator FadeOut(UnityEngine.UI.Image ima)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        ima.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ima.color = endColor;

        if (disableAfterFadeOut)
        {
            ima.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(UnityEngine.UI.Image ima)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        ima.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ima.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            ima.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
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
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ren.material.color = endColor;
    }
    private IEnumerator FadeOut(Renderer ren)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        ren.material.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ren.material.color = endColor;

        if (disableAfterFadeOut)
        {
            ren.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(Renderer ren)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        ren.material.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        ren.material.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            ren.material.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
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
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeIn);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        text.color = endColor;
    }
    private IEnumerator FadeOut(TextMeshProUGUI text)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        text.color = startColor;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(startColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(startColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(startColor.a, endColor.a, elapsedTime / durationFadeOut);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        text.color = endColor;

        if (disableAfterFadeOut)
        {
            text.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(TextMeshProUGUI text)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        text.color = startColor;
        while (elapsedTime < durationFadeIn)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(startColor.r, targetColor.r, elapsedTime / durationFadeIn);
            float b = Mathf.Lerp(startColor.b, targetColor.b, elapsedTime / durationFadeIn);
            float g = Mathf.Lerp(startColor.g, targetColor.g, elapsedTime / durationFadeIn);
            float a = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / durationFadeIn);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        text.color = targetColor;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float r = Mathf.Lerp(targetColor.r, endColor.r, elapsedTime / durationFadeOut);
            float b = Mathf.Lerp(targetColor.b, endColor.b, elapsedTime / durationFadeOut);
            float g = Mathf.Lerp(targetColor.g, endColor.g, elapsedTime / durationFadeOut);
            float a = Mathf.Lerp(targetColor.a, endColor.a, elapsedTime / durationFadeOut);

            text.color = new Color(r, b, g, a);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        text.color = endColor;

        if (disableAfterFadeOut)
        {
            text.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeIn(AudioSource audio)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        //��ʼ����
        audio.volume = startVolume;
        while (elapsedTime < durationFadeIn)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(startVolume, endVolume, elapsedTime / durationFadeIn);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        audio.volume = endVolume;
    }
    private IEnumerator FadeOut(AudioSource audio)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        //��ʼ����
        audio.volume = startVolume;
        while (elapsedTime < durationFadeOut)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(startVolume, endVolume, elapsedTime / durationFadeOut);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        audio.volume = endVolume;

        if (disableAfterFadeOut)
        {
            audio.transform.gameObject.SetActive(false);
        }
    }
    private IEnumerator FadeInOut(AudioSource audio)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        //��ʼ����
        audio.volume = startVolume;
        while (elapsedTime < durationFadeIn)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(startVolume, targetVolume, elapsedTime / durationFadeIn);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        audio.volume = targetVolume;
        yield return new WaitForSeconds(stayTime);
        elapsedTime = 0f;
        while (elapsedTime < durationFadeOut)
        {
            float alpha = Mathf.Lerp(targetVolume, endVolume, elapsedTime / durationFadeOut);
            audio.volume = alpha;
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //����ʱ�����
        audio.volume = endVolume;

        if (disableAfterFadeOut)
        {
            audio.transform.gameObject.SetActive(false);
        }
    }

}
