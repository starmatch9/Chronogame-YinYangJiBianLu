using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlock : MonoBehaviour
{

    //场景加载时解锁对应关卡
    void Start()
    {
        //获取当前场景的名称
        string name = SceneManager.GetActiveScene().name;
        // 保存字符串数据
        PlayerPrefs.SetInt(name, 1);
        // 调用 Save 方法将数据写入磁盘
        PlayerPrefs.Save();

        // 加载测试
        if( PlayerPrefs.GetInt(name, 0) == 1)
        {
            Debug.Log("成了");
        }
    }
}
