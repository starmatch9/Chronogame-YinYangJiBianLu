using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUI : MonoBehaviour
{
    //��ʼ��Ϸ�ķ���
    public void newGame()
    {
        SceneManager.LoadScene("Yin-Yang-1");
    }


    //ѡ��ؿ��ķ���
    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }


    //�˳���Ϸ�ķ���
    public void exitGame()
    {
        //�˳�
        //Application.Quit();

        //���ԡ���ɾ�����б��������
        PlayerPrefs.DeleteAll();
    }
}
