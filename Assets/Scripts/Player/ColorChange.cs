using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //�鿴�������Ƿ����
    public Process process;

    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        //��ʼ��Ϊ��ɫ
        renderer.material.color = Color.white;
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
        if(renderer.material.color == Color.white)
        {
            renderer.material.color = Color.black;
        }
        else
        {
            renderer.material.color = Color.white;
        }
    }
}
