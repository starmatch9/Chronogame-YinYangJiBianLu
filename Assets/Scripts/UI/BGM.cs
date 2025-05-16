using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BGM : MonoBehaviour
{
    //�ο�BGMmanager�ű�
    public AudioSource audioSource;
    public VideoPlayer player;

    void Start()
    {
        //��Ӽ�����
        player.loopPointReached += CheckVideoCompletion;

        //����1�����״μ���
        if (PlayerPrefs.HasKey("video"))
        {
            StartCoroutine(load());
        }

    }
    //�¼���������
    void CheckVideoCompletion(VideoPlayer vp)
    {
        //��Ȼ��֪��ԭ����ʲô�����Ǻܺ���
        StartCoroutine(load());
    }
    //����
    private IEnumerator load()
    {
        //���ÿ�ʼ����Ϊ0
        audioSource.volume = 0f;
        audioSource.Play();
        //�ۼ�ʱ��
        float elapsed = 0;
        while (elapsed < 5f)
        {
            audioSource.volume = Mathf.Lerp(0f, 0.05f, elapsed / 5f);
            //����
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0.05f;
    }
    //����
    private IEnumerator fade()
    {
        //��Ϊ��׼��1
        audioSource.volume = 0.05f;
        //�ۼ�ʱ��
        float elapsed = 0;
        while (elapsed < 1f)
        {
            audioSource.volume = Mathf.Lerp(0.05f, 0f, elapsed / 1f);
            //����
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0f;
    }
}
