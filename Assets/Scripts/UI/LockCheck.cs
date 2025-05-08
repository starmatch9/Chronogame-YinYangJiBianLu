using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCheck : MonoBehaviour
{
    public void check()
    {
        //��ȡ�������ƣ��볡����һһ��Ӧ
        string name = gameObject.name;
        // �������������壬�ҵ���ǩ��Lock��
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Lock"))
            {
                //����
                if(PlayerPrefs.GetInt(name, 0) == 1)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
