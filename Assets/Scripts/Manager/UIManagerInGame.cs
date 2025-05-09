using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerInGame : MonoBehaviour
{
    public void mainMenus()
    {
        SceneManager.LoadScene("Start");
    }

    //禁用
    public void disableScripts()
    {
        // 查找标签为Player的物体
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            //错误检出
            Debug.LogWarning("未找到标签为Player的物体");
            return;
        }

        //禁用Player自身的所有脚本
        MonoBehaviour[] playerScripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in playerScripts)
        {
            if (script != null && script.enabled)
                script.enabled = false;
        }

        // 禁用所有子物体的脚本
        MonoBehaviour[] childScripts = player.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in childScripts)
        {
            if (script != null && script.enabled && script.gameObject != player)
                script.enabled = false;
        }
    }

    //恢复
    public void enableScripts()
    {
        // 查找标签为Player的物体
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            //错误检出
            Debug.LogWarning("未找到标签为Player的物体");
            return;
        }

        //禁用Player自身的所有脚本
        MonoBehaviour[] playerScripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in playerScripts)
        {
            if (script != null && !script.enabled)
                script.enabled = true;
        }

        // 禁用所有子物体的脚本
        MonoBehaviour[] childScripts = player.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in childScripts)
        {
            if (script != null && !script.enabled && script.gameObject != player)
                script.enabled = true;
        }
    }
}
