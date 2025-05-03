using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class AreaNumManager : MonoBehaviour
{
    public string sceneName;

    public SceneLoad sl;

    private void Update()
    {
        //��⵽��Ϸ������ʱ��ڵ�
        if(areaNum() == 0)
        {
            Debug.Log("��Ϸ������������");
            sl.load(sceneName);
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
            if(child.gameObject.activeSelf && 
                (child.gameObject.layer == LayerMask.NameToLayer("YinArea") ||
                child.gameObject.layer == LayerMask.NameToLayer("YangArea")))
            {
                count++;
            }
        }
        return count;
    }
}
