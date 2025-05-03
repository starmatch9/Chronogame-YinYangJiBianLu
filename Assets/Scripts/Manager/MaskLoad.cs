using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//封装存有加载黑底白字的方法
public class MaskLoad : MonoBehaviour
{
    public Image image;

    public IEnumerator loadText()
    {
        //运行时间，用于累加
        float elapsedTime = 0f;
        Color startColor = image.GetComponent<Color>();
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 255);
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);


        while (elapsedTime < 2.0f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //等待下一帧
            yield return null;
        }

        yield return null;
    }

}
