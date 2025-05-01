using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class AreaNumManager : MonoBehaviour
{

    private void Update()
    {
        if(areaNum() == 0)
        {
            Debug.Log("��Ϸ������������");
        }
    }

    //��ȡ������������������
    public int areaNum()
    {
        int count = 0;

        //��ȡ����������
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        //����ÿһ��������
        foreach (Transform child in allChildren)
        {
            //ɸѡ����Ĳ����ǶԵ�ͼ��
            if(child.gameObject.active && 
                (child.gameObject.layer == LayerMask.NameToLayer("YinArea") ||
                child.gameObject.layer == LayerMask.NameToLayer("YangArea")))
            {
                count++;
            }
        }
        return count;
    }
}
