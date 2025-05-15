using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        //场景开始淡出
        StartCoroutine(fade());
    }

    //文本淡入淡出
    public IEnumerator textLoad()
    {
        //运行时间
        float elapsedTime = 0f;
        //确定颜色变化的时间节点
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        //淡入
        while (elapsedTime < 2f)
        {
            //按照百分比从0到1插值
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 2f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制黑
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //等待10秒
        yield return new WaitForSeconds(10f);
        //重置运行时间
        elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        textMeshPro.color = noColor;
    }

    //黑色变白
    public IEnumerator fade()
    {
        //切换场景不销毁
        DontDestroyOnLoad(gameObject);

        yield return StartCoroutine(textLoad());

        float elapsedTime = 0f;
        Color endColor = new Color(0f, 0f, 0f, 0f);

        SceneManager.LoadScene("Start");

        while (elapsedTime < 3.0f)
        {
            //按照百分比从0到1插值
            float c = Mathf.Lerp(1, 0, elapsedTime / 3.0f);
            background.color = new Color(0f, 0f, 0f, c);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }
        //强制
        background.color = endColor;

        //手动销毁
        Destroy(gameObject);
    }
}
