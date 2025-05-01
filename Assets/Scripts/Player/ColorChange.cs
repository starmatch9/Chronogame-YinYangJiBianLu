using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Process process;

    Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
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
