using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class AreaNumManager : MonoBehaviour
{
    public string sceneName;

    public SceneLoad sl;

    private void Update()
    {
        //检测到游戏结束的时间节点
        if(areaNum() == 0)
        {
            Debug.Log("游戏结束！！！！");
            sl.load(sceneName);
        }
    }

    //获取阴区和阳区的总数量
    public int areaNum()
    {
        int count = 0;

        //获取所有子物体
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        //遍历每一个子物体
        foreach (Transform child in allChildren)
        {
            //筛选激活的并且是对的图层
            if(child.gameObject.activeSelf && 
                (child.gameObject.layer == LayerMask.NameToLayer("YinArea") ||
                child.gameObject.layer == LayerMask.NameToLayer("YangArea")))
            {
                count++;
            }
        }
        return count;
    }
}
