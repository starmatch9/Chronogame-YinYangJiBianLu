using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //ѡ����Ч
    public AudioClip sfx;
    //��������
    float volume = 0.1f;

    public void sfxPlay()
    {
        //�������λ�ø�������
        Vector3 position = Camera.main.transform.position;
        //��̬�Ĳ��ŷ���
        AudioSource.PlayClipAtPoint(sfx, position, volume);
    }
}
