using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThroughDoor : MonoBehaviour
{
    //������ȡ��ɫ����ɫ
    public ColorChange cc;

    //���Ϊtrue�ſ��Լ�¼���λ��
    bool isCheck = true;

    //������¼��ҽ���ǰ��λ�ã��Ӷ������޷�����������
    Vector3 previousPosition;

    private void Update()
    {
        if (isCheck)
        {
            //ÿ�μ��һ�����λ��
            previousPosition = transform.position;
        }  
    }

    //��⵽�Է�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCheck = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("YinDoor"))
        {
            //�������ǡ������ܴ���������������,ֻ��������λ�ü���
            if(cc.ren.material.color == Color.white)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            //ͬ��
            if (cc.ren.material.color == Color.black)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isCheck = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("YinDoor"))
        {
            //�������ǡ������ܴ���������������
            if (cc.ren.material.color == Color.white)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            //ͬ��
            if (cc.ren.material.color == Color.black)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCheck = true;
    }
}
