using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//����Ƶ���Ž����󱳾�����
public class VideoFinal : MonoBehaviour
{
    public VideoPlayer vp;
    //��¼�����ʱ��ڵ�
    float startFadeTime;
    void Start()
    {
        //�������������Ƶ���Ž����¼�
        vp.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // ��¼��ʼ�����ʱ��
        startFadeTime = Time.time;
    }
    void Update()
    {
        // �����Ƶ���Ž���
        if (startFadeTime > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
