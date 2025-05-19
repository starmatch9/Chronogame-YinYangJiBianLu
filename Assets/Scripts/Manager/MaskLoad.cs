using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//封装存有加载黑底白字的方法
public class MaskLoad : MonoBehaviour
{
    public Image image;
    //测试后无法换行，故加入3个，意思是三行
    public string textContent1 = "";
    public string textContent2 = "";
    public string textContent3 = "";
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        image.color = new Color(0f, 0f, 0f, 1f);
        //场景开始淡出
        StartCoroutine(fade());
    }
    //游戏结束加载黑色
    public IEnumerator load()
    {
        image.gameObject.SetActive(true);
        //运行时间，用于累加
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < 1.0f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        image.color = midColor;
    }

    //游戏开始黑色渐出
    public IEnumerator fade()
    {



        /*不太好加，可能需要较大改动*/
        //鼠标点击任意处退出
        //float skipTime = 0f;
        //while (!Input.GetMouseButtonDown(0) && skipTime <= 3f) 
        //{
        //    skipTime += Time.deltaTime;
        //    yield return null;
        //}
        string name = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.GetInt(name, 0) != 1)
        {
            //引入文字显示
            string textContent = textContent1 + "\n" + textContent2 + "\n" + textContent3;
            StartCoroutine(textLoad(textContent));
            yield return new WaitForSeconds(3f);
        }


        //运行时间，用于累加
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < 1.0f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        image.color = endColor;

        // 查找player并激活
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Move>().enabled = true;
        }
        image.gameObject.SetActive(false);
    }
    //文本淡入淡出
    public IEnumerator textLoad(string content)
    {
        //设置文本内容
        textMeshPro.text = content;
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        //淡入0.5秒
        while (elapsedTime < 0.5f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //等待2.5秒
        yield return new WaitForSeconds(2.5f);
        //重置运行时间
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        textMeshPro.color = noColor;
    }
}
