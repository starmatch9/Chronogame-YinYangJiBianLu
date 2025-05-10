using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThroughDoor : MonoBehaviour
{
    //用来获取角色的颜色
    public ColorChange cc;

    //这个为true才可以记录玩家位置
    bool isCheck = true;

    //用来记录玩家进入前的位置，从而让其无法进入阴阳门
    Vector3 previousPosition;

    private void Update()
    {
        if (isCheck)
        {
            //每次检测一次玩家位置
            previousPosition = transform.position;
        }  
    }

    //检测到对方是门
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCheck = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("YinDoor"))
        {
            //如果玩家是“阴”能穿过，“阳”不行,只锁定横向位置即可
            if(cc.ren.material.color == Color.white)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            //同理
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
            //如果玩家是“阴”能穿过，“阳”不行
            if (cc.ren.material.color == Color.white)
            {
                transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            //同理
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
