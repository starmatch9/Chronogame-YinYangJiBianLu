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
        //������ʼ����
        StartCoroutine(fade());
    }

    //�ı����뵭��
    public IEnumerator textLoad()
    {
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;

        //����
        while (elapsedTime < 2f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 2f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ�ƺ�
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
        //�ȴ�10��
        yield return new WaitForSeconds(10f);
        //��������ʱ��
        elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        textMeshPro.color = noColor;
    }

    //��ɫ���
    public IEnumerator fade()
    {
        //�л�����������
        DontDestroyOnLoad(gameObject);

        yield return StartCoroutine(textLoad());

        float elapsedTime = 0f;
        Color endColor = new Color(0f, 0f, 0f, 0f);

        SceneManager.LoadScene("Start");

        while (elapsedTime < 3.0f)
        {
            //���հٷֱȴ�0��1��ֵ
            float c = Mathf.Lerp(1, 0, elapsedTime / 3.0f);
            background.color = new Color(0f, 0f, 0f, c);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        //ǿ��
        background.color = endColor;

        //�ֶ�����
        Destroy(gameObject);
    }
}
