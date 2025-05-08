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
    public void selectLevel()
    {

    }


    //退出游戏的方法
    public void exitGame()
    {
        Application.Quit();
    }
}
