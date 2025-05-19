using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    //��Ϸ�������غ�ɫ
    public IEnumerator load()
    {
        image.gameObject.SetActive(true);
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

    //��Ϸ��ʼ��ɫ����
    public IEnumerator fade()
    {



        /*��̫�üӣ�������Ҫ�ϴ�Ķ�*/
        //��������⴦�˳�
        //float skipTime = 0f;
        //while (!Input.GetMouseButtonDown(0) && skipTime <= 3f) 
        //{
        //    skipTime += Time.deltaTime;
        //    yield return null;
        //}
        string name = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.GetInt(name, 0) != 1)
        {
            //����������ʾ
            string textContent = textContent1 + "\n" + textContent2 + "\n" + textContent3;
            StartCoroutine(textLoad(textContent));
            yield return new WaitForSeconds(3f);
        }


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
        }
        image.gameObject.SetActive(false);
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
