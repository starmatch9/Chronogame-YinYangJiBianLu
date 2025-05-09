using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//����Ƶ���Ž����󱳾�����
public class VideoFinal : MonoBehaviour
{
    public VideoPlayer player;

    public AudioSource audioSource;
    public AudioSource birdAudioSource;

    //������Ƶ��������ԭʼͼ��
    public RawImage videoImage;

    //�ο�MaskLoad��
    public TextMeshProUGUI textMeshPro;

    Image image;

    void Start()
    {
        //��Ӽ�����
        player.loopPointReached += CheckVideoCompletion;

        image = GetComponent<Image>();

        //����1�����״μ���
        if (!PlayerPrefs.HasKey("video"))
        {
            //������Ƶ�ķ���
            StartCoroutine(play());
        }
        else
        {
            //�����״μ���,��������,��ǰ������п�ʼ
            birdAudioSource.Play();

            gameObject.transform.parent.gameObject.SetActive(false);
        }


    }
    //�¼���������
    void CheckVideoCompletion(VideoPlayer vp)
    {
        //��Ȼ��֪��ԭ����ʲô�����Ǻܺ��ã���л������
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        //�տ�ʼ��͸��
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
        //׼����������
        string textContent = "��������������������\r\n���������������˺͡�\r\n����˱������У�\r\n��νƽ��֮��Ҫ��";
        yield return StartCoroutine(textLoad(textContent));
        //��������ʾ������background�Ľ�����ʧ

        //��ʼ���
        birdAudioSource.Play();

        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //��һ֡�����йض���
        yield return null;

        PlayerPrefs.SetInt("video", 1);
        PlayerPrefs.Save();

        gameObject.transform.parent.gameObject.SetActive(false);

    }

    public IEnumerator textLoad(string content)
    {
        //�����ı�����
        textMeshPro.text = content;
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        //����¼��
        audioSource.Play();

        //����0.5��
        while (elapsedTime < 0.5f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //�ȴ�2.5��
        yield return new WaitForSeconds(11f);
        //��������ʱ��
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        textMeshPro.color = noColor;
    }
}
