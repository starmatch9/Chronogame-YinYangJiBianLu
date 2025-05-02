using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //查看进度条是否结束
    public Process process;

    public Color color = Color.white;

    //这是渲染器
    [HideInInspector]
    public Renderer ren;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        //初始化为白色
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
    //改变颜色的方法
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
