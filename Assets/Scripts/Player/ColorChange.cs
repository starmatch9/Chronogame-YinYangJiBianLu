using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //�鿴�������Ƿ����
    public Process process;

    public Color color = Color.white;

    //������Ⱦ��
    [HideInInspector]
    public Renderer ren;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        //��ʼ��Ϊ��ɫ
        ren.material.color = color;
    }
    private void Update()
    {
        if (process.change)
        {
            process.change = false;
            change();
        }
    }
    //�ı���ɫ�ķ���
    private void change()
    {
        if(ren.material.color == Color.white)
        {
            ren.material.color = Color.black;
        }
        else
        {
            ren.material.color = Color.white;
        }
    }
}
