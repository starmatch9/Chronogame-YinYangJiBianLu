using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    //teach是教程的背景，为黑色
    public GameObject teachObject;
    public AudioSource bird;
    public AudioSource bgm;

    //专用bgm
    public AudioSource teachBGM;

    public Image step1;
    public TextMeshProUGUI step2;
    public TextMeshProUGUI step3;
    public Image step4;
    public TextMeshProUGUI step4t;
    public Image step5;
    public TextMeshProUGUI step5t;
    public Image step6;
    public TextMeshProUGUI step6t;
    public TextMeshProUGUI step7;




    //开始游戏的方法
    public void newGame()
    {
        StartCoroutine(teach());
    }


    //选择关卡的方法
    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }


    //退出游戏的方法
    public void exitGame()
    {
        //删掉首次播放开头动画的标志
        PlayerPrefs.DeleteKey("video");

        //退出
        Application.Quit();

        //测试——删除所有保存的数据
        //PlayerPrefs.DeleteAll();
    }



    //编写加载故事背景的函数
    public IEnumerator teach()
    {
        //音乐停
        bird.Stop();
        bgm.Stop();

        //渐变为黑色
        Image image = teachObject.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 0f);
        teachObject.SetActive(true);
        float elapsed = 0;
        while (elapsed < 2f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / 2f);
            image.color = new Color(0f, 0f, 0f, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(0f, 0f, 0f, 1f);
        //专属音乐启动
        StartCoroutine(bgmPlay());
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(imageLoad(step1));
        yield return StartCoroutine(textLoad(step2));

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(textLoad(step3));

        yield return new WaitForSeconds(4f);

        StartCoroutine(imageLoad(step4));
        yield return StartCoroutine(textLoad(step4t));

        yield return new WaitForSeconds(4f);

        StartCoroutine(imageLoad(step5));
        yield return StartCoroutine(textLoad(step5t));

        yield return new WaitForSeconds(5f);













        yield return null;
        //SceneManager.LoadScene("Yin-Yang-1");
    }

    public IEnumerator bgmPlay()
    {
        //设置专属音乐
        //设置开始音量为0
        teachBGM.volume = 0f;
        teachBGM.Play();
        //累计时间
        float elapsed = 0;
        while (elapsed < 3f)
        {
            teachBGM.volume = Mathf.Lerp(0f, 0.05f, elapsed / 3f);
            //增量
            elapsed += Time.deltaTime;
            yield return null;
        }
        teachBGM.volume = 0.05f;
    }

    //文本淡入
    public IEnumerator textLoad(TextMeshProUGUI textMeshPro)
    {
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;
        //淡入0.5秒
        while (elapsedTime < 1.5f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
    //文本淡出
    public IEnumerator textFade(TextMeshProUGUI textMeshPro)
    {
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        textMeshPro.color = noColor;
    }
    //图像淡入
    public IEnumerator imageLoad(Image image)
    {
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = image.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        image.color = noColor;
        //淡入0.5秒
        while (elapsedTime < 1.5f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.5f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        image.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
    //文本淡出
    public IEnumerator imagetFade(Image image)
    {
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = image.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.5f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        image.color = noColor;
    }
}
