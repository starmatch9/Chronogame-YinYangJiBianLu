using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//��װ���м��غڵװ��ֵķ���
public class MaskLoad : MonoBehaviour
{
    public Image image;
    //���Ժ��޷����У��ʼ���3������˼������
    public string textContent1 = "";
    public string textContent2 = "";
    public string textContent3 = "";
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        image.color = new Color(0f, 0f, 0f, 1f);
        //������ʼ����
        StartCoroutine(fade());
    }
    //���ı��Ƶ��ⲿ����ʵ��
    public IEnumerator load()
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (elapsedTime < 1.0f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        image.color = midColor;
    }

    public IEnumerator fade()
    {
        //����������ʾ
        string textContent = textContent1 + "\n" + textContent2 +"\n" + textContent3;
        StartCoroutine(textLoad(textContent));

        yield return new WaitForSeconds(3);
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < 1.0f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.0f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        image.color = endColor;

        // ����player������
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.GetComponent<Move>().enabled = true;
            Debug.Log("Ϊʲô���ܶ���");
        }
    }
    //�ı����뵭��
    public IEnumerator textLoad(string content)
    {
        //�����ı�����
        textMeshPro.text = content;
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        Debug.Log("�����ı���");

        //����0.5��
        while (elapsedTime < 0.5f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //�ȴ�2.5��
        yield return new WaitForSeconds(2.5f);
        //��������ʱ��
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        textMeshPro.color = noColor;
    }
}
