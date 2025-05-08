using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUI : MonoBehaviour
{
    //开始游戏的方法
    public void newGame()
    {
        SceneManager.LoadScene("Yin-Yang-1");
    }


    //选择关卡的方法
    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }


    //退出游戏的方法
    public void exitGame()
    {
        //退出
        //Application.Quit();

        //测试——删除所有保存的数据
        PlayerPrefs.DeleteAll();
    }
}
