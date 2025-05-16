using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    //用来获取角色的颜色
    public ColorChange cc;

    public Collider2D yangDoorCol;
    public Collider2D yinDoorCol;

    private void Update()
    {
        if (yangDoorCol != null || yinDoorCol != null)
        {
            if (cc.ren.sprite == cc.YinYu)//当角色为阴鱼时开启阴门碰撞，关闭阳门碰撞
            {
                yinDoorCol.enabled = false;
                yangDoorCol.enabled = true;
            }
            if (cc.ren.sprite == cc.YangYu)//同理
            {
                yinDoorCol.enabled = true;
                yangDoorCol.enabled = false;
            }
        }
    }
}
