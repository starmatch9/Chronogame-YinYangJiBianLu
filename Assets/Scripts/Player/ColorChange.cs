using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //查看进度条是否结束
    public Process process;

    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        //初始化为白色
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
    //改变颜色的方法
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
