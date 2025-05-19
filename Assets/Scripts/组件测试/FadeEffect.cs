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

    /*Ч���������*/
    [Header("Ч����������")]
    //һ��ʼ���û�ѡ���뵭����Ŀ�������ʲô
    [Tooltip("ֻ�б�ѡ�еġ�target���ϵ����ݲŻ���Ч")]
    public FadeTarget target = FadeTarget.Audio;
    public AudioSource audioSource = null;
    public TextMeshProUGUI textMeshPro = null;
    public Renderer spriteRenderer = null;
    public Image image = null;

    /*���뵭���������*/
    [Header("���뵭������")]
    //ѡ��Ч�����ͣ���ֻ���룿����ֻ�����������������뵭��
    public FadeType fadeType = FadeType.FadeIn;
    //����ʱ��
    public float duration = 1.0f;
    //�ӳٶ೤ʱ�����
    public float delay = 0f;
    public bool playOnStart = true;
    //��������������Ϊδ����
    public bool disableAfterFadeOut = false;


    /*��ɫ�������*/
    [Header("��ɫ����")]

    [Tooltip("Ч����ʼʱ����ɫ")]
    public Color startColor = Color.black;

    [Tooltip("��ѡ��Fade In Out��ʱ��Ч����ʾ�м���ʾ����ɫ")]
    public Color targetColor = Color.white;

    [Tooltip("Ч������ʱ����ɫ")]
    public Color endColor = Color.black;

    private IEnumerator FadeIn()
    {
        


        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < 1.0f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        image.color = midColor;


    }

}
