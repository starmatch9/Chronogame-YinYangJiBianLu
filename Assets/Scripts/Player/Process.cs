using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Process : MonoBehaviour
{
    //��������������Σ�
    public Image process;
    //�������ļ����ٶ�
    public float speed = 0.5f;

    //�����������Ƭ����
    GameObject area = null;

    //�Ƿ�ʼ���ı�־
    bool fill = false;

    //�Ƿ�ת����ɫ�ı�־
    [HideInInspector]
    public bool change = false;

    //������ȡ��ɫ����ɫ
    public ColorChange cc;

    private void Awake()
    {
        process = transform.GetComponent<Image>();
    }
    private void Update()
    {
        if (fill)
        {
            //���ٶȼ���
            process.fillAmount += Time.deltaTime * speed;
            if (process.fillAmount >= 1f)
            {
                //ͣ�ý�����
                process.fillAmount = 0f;
                if(area != null)
                {
                    //������ɺ�������ʧ
                    area.SetActive(false);
                    change = true;
                }
            }
        }
    }
    //��⵽��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea"))
        {
            area = collision.gameObject;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea"))
        {
            area = collision.gameObject;
        }
    }
    //����������������ʱ������־��Ч
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea") && cc.ren.material.color == Color.white)
        {
            fill = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea") && cc.ren.material.color == Color.black)
        {
            fill = true;
        }
    }
    //��ȥ���򣬱�־ʧЧ����������գ�area���������ڵ�����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea"))
        {
            fill = false;
            process.fillAmount = 0f;
            area = null;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea"))
        {
            fill = false;
            process.fillAmount = 0f;
            area = null;
        }
    }

}
