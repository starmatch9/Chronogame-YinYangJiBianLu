using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//封装存有加载黑底白字的方法
public class MaskLoad : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        image.color = new Color(0f, 0f, 0f, 1f);
        //场景开始淡出
        StartCoroutine(Fade());
    }

    public IEnumerator loadText()
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        Debug.Log("加载文本中");

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
        yield return new WaitForSeconds(2);
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        //运行时间，用于累加
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        Debug.Log("加载文本中");

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

}
