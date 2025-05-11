using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notice : MonoBehaviour
{
    Collider2D col;
    Coroutine runningCoroutine;
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        col = GetComponent<Collider2D>();
        runningCoroutine = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
        runningCoroutine = StartCoroutine(load());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
        runningCoroutine = StartCoroutine(fade());
    }

    //文本淡入淡出
    public IEnumerator load()
    {
        //从0开始计时
        float elapsedTime = 0f;

        Color noColor = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, textMeshPro.color.a);
        textMeshPro.color = noColor;

        //淡入0.5秒
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator fade()
    {
        //从0开始计时
        float elapsedTime = 0f;

        Color yesColor = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, textMeshPro.color.a);
        textMeshPro.color = yesColor;

        //淡出0.5秒
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
