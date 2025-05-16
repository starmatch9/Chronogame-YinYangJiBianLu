using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    //������ȡ��ɫ����ɫ
    public ColorChange cc;

    public Collider2D yangDoorCol;
    public Collider2D yinDoorCol;

    private void Update()
    {
        if (yangDoorCol != null || yinDoorCol != null)
        {
            if (cc.ren.sprite == cc.YinYu)//����ɫΪ����ʱ����������ײ���ر�������ײ
            {
                yinDoorCol.enabled = false;
                yangDoorCol.enabled = true;
            }
            if (cc.ren.sprite == cc.YangYu)//ͬ��
            {
                yinDoorCol.enabled = true;
                yangDoorCol.enabled = false;
            }
        }
    }
}
