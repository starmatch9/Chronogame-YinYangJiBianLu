using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//��װ���м��غڵװ��ֵķ���
public class MaskLoad : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        image.color = new Color(0f, 0f, 0f, 1f);
        //������ʼ����
        StartCoroutine(Fade());
    }

    public IEnumerator loadText()
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color midColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        Debug.Log("�����ı���");

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
        yield return new WaitForSeconds(2);
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        image.color = new Color(0f, 0f, 0f, 0f);
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        Debug.Log("�����ı���");

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

}
