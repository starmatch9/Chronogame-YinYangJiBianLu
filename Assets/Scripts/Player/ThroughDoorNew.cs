using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThroughDoorNew : MonoBehaviour
{
    //用来获取角色的颜色
    public ColorChange cc;

    public Collider2D yangDoorCol;
    public Collider2D yinDoorCol;

    private void Update()
    {
        if (cc.ren.sprite == cc.YangYu)
        {
            yinDoorCol.enabled = true;
            yangDoorCol.enabled = false;
        }
        if (cc.ren.sprite == cc.YinYu)
        {
            yinDoorCol.enabled = false;
            yangDoorCol.enabled = true;

        }
    }
}
