using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    //����������Ϸ�Ƿ��������Ϣ
    //ʱ���ߣ�������ʼ��3�뵭�룬������������0ʱ����
    public AreaNumManager areaNumManager;

    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(load());
    }

    private void Update()
    {
        if (areaNumManager.areaNum() == 0)
        {
            StartCoroutine(fade());
        }
    }
    //����
    private IEnumerator load()
    {
        //���ÿ�ʼ����Ϊ0
        audioSource.volume = 0f;

        //��3������ʱ���ʼ����
        yield return new WaitForSeconds(3f);
        audioSource.Play();
        //�ۼ�ʱ��
        float elapsed = 0;
        while (elapsed < 2f)
        {
            audioSource.volume = Mathf.Lerp(0f, 0.05f, elapsed / 2f);
            //����
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0.05f;
    }
    //����
    private IEnumerator fade()
    {
        //��Ϊ��׼��0.2
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
