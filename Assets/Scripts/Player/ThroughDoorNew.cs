using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThroughDoorNew : MonoBehaviour
{
    //������ȡ��ɫ����ɫ
    public ColorChange cc;

    public Collider2D doorCol;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinDoor"))
        {
            if(cc.ren.sprite == cc.YangYu)
            {
                doorCol = collision;
                collision.enabled = false;
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            //ͬ��
            if (cc.ren.sprite == cc.YinYu)
            {
                doorCol = collision;
                collision.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision == doorCol)
        //{
            collision.enabled = true;
            doorCol = null;
        //}
    }
}
