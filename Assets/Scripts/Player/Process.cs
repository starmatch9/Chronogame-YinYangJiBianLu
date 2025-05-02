using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Process : MonoBehaviour
{
    //调理进度条（环形）
    public Image process;
    //进度条的加载速度
    public float speed = 0.5f;

    //现在玩家在那片区域
    GameObject area = null;

    //是否开始填充的标志
    bool fill = false;

    //是否转化颜色的标志
    [HideInInspector]
    public bool change = false;

    //用来获取角色的颜色
    public ColorChange cc;

    private void Awake()
    {
        process = transform.GetComponent<Image>();
    }
    private void Update()
    {
        if (fill)
        {
            //按速度加载
            process.fillAmount += Time.deltaTime * speed;
            if (process.fillAmount >= 1f)
            {
                //停用进度条
                process.fillAmount = 0f;
                if(area != null)
                {
                    //调理完成后区域消失
                    area.SetActive(false);
                    change = true;
                }
            }
        }
    }
    //检测到阴区阳区
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
    //在阴区或者阳区里时，填充标志生效
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
    //出去区域，标志失效，进度条清空，area不保存现在的区域
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
