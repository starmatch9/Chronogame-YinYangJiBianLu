using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlock : MonoBehaviour
{

    //��������ʱ������Ӧ�ؿ�
    void Start()
    {
        //��ȡ��ǰ����������
        string name = SceneManager.GetActiveScene().name;
        // �����ַ�������
        PlayerPrefs.SetInt(name, 1);
        // ���� Save ����������д�����
        PlayerPrefs.Save();

        // ���ز���
        if( PlayerPrefs.GetInt(name, 0) == 1)
        {
            Debug.Log("����");
        }
    }
}
