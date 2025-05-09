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

    //����
    public void disableScripts()
    {
        // ���ұ�ǩΪPlayer������
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            //������
            Debug.LogWarning("δ�ҵ���ǩΪPlayer������");
            return;
        }

        //����Player��������нű�
        MonoBehaviour[] playerScripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in playerScripts)
        {
            if (script != null && script.enabled)
                script.enabled = false;
        }

        // ��������������Ľű�
        MonoBehaviour[] childScripts = player.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in childScripts)
        {
            if (script != null && script.enabled && script.gameObject != player)
                script.enabled = false;
        }
    }

    //�ָ�
    public void enableScripts()
    {
        // ���ұ�ǩΪPlayer������
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            //������
            Debug.LogWarning("δ�ҵ���ǩΪPlayer������");
            return;
        }

        //����Player��������нű�
        MonoBehaviour[] playerScripts = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in playerScripts)
        {
            if (script != null && !script.enabled)
                script.enabled = true;
        }

        // ��������������Ľű�
        MonoBehaviour[] childScripts = player.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour script in childScripts)
        {
            if (script != null && !script.enabled && script.gameObject != player)
                script.enabled = true;
        }
    }
}
