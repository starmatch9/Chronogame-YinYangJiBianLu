using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
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
    //将文本移到外部独立实现
    public IEnumerator load()
    {
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

    public IEnumerator fade()
    {
        //引入文字显示
        string textContent = textContent1 + "\n" + textContent2 +"\n" + textContent3;
        StartCoroutine(textLoad(textContent));

        yield return new WaitForSeconds(3);
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
            Debug.Log("为什么不能动！");
        }
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

        Debug.Log("加载文本中");

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
