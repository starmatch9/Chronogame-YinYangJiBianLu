using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //ѡ����Ч
    public AudioClip sfx;
    //��������
    public float volume = 0.3f;

    private void Awake()
    {
        //�˷������Ա�֤�л�����ʱ������
        DontDestroyOnLoad(gameObject);
    }

    public void sfxPlay()
    {
        //�������λ�ø�������
        Vector3 position = Camera.main.transform.position;
        //��̬�Ĳ��ŷ���
        AudioSource.PlayClipAtPoint(sfx, position, volume);
    }
}
