using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerUI : MonoBehaviour
{
    //teach�ǽ̵̳ı�����Ϊ��ɫ
    public GameObject teachObject;
    public AudioSource bird;
    public AudioSource bgm;

    //ר��bgm
    public AudioSource teachBGM;

    public Image step1;
    public TextMeshProUGUI step2;
    public TextMeshProUGUI step3;
    public Image step4;
    public TextMeshProUGUI step4t;
    public Image step5;
    public TextMeshProUGUI step5t;
    public Image step6;
    public TextMeshProUGUI step6t;
    public TextMeshProUGUI step7;




    //��ʼ��Ϸ�ķ���
    public void newGame()
    {
        StartCoroutine(teach());
    }


    //ѡ��ؿ��ķ���
    public void selectLevel(string name)
    {
        SceneManager.LoadScene(name);
    }


    //�˳���Ϸ�ķ���
    public void exitGame()
    {
        //ɾ���״β��ſ�ͷ�����ı�־
        PlayerPrefs.DeleteKey("video");

        //�˳�
        Application.Quit();

        //���ԡ���ɾ�����б��������
        //PlayerPrefs.DeleteAll();
    }



    //��д���ع��±����ĺ���
    public IEnumerator teach()
    {
        //����ͣ
        bird.Stop();
        bgm.Stop();

        //����Ϊ��ɫ
        Image image = teachObject.GetComponent<Image>();
        image.color = new Color(0f, 0f, 0f, 0f);
        teachObject.SetActive(true);
        float elapsed = 0;
        while (elapsed < 2f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsed / 2f);
            image.color = new Color(0f, 0f, 0f, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(0f, 0f, 0f, 1f);
        //ר����������
        StartCoroutine(bgmPlay());
        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(imageLoad(step1));
        yield return StartCoroutine(textLoad(step2));

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(textLoad(step3));

        yield return new WaitForSeconds(4f);

        StartCoroutine(imageLoad(step4));
        yield return StartCoroutine(textLoad(step4t));

        yield return new WaitForSeconds(4f);

        StartCoroutine(imageLoad(step5));
        yield return StartCoroutine(textLoad(step5t));

        yield return new WaitForSeconds(5f);













        yield return null;
        //SceneManager.LoadScene("Yin-Yang-1");
    }

    public IEnumerator bgmPlay()
    {
        //����ר������
        //���ÿ�ʼ����Ϊ0
        teachBGM.volume = 0f;
        teachBGM.Play();
        //�ۼ�ʱ��
        float elapsed = 0;
        while (elapsed < 3f)
        {
            teachBGM.volume = Mathf.Lerp(0f, 0.05f, elapsed / 3f);
            //����
            elapsed += Time.deltaTime;
            yield return null;
        }
        teachBGM.volume = 0.05f;
    }

    //�ı�����
    public IEnumerator textLoad(TextMeshProUGUI textMeshPro)
    {
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        textMeshPro.color = noColor;
        //����0.5��
        while (elapsedTime < 1.5f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
    //�ı�����
    public IEnumerator textFade(TextMeshProUGUI textMeshPro)
    {
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = textMeshPro.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.5f);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        textMeshPro.color = noColor;
    }
    //ͼ����
    public IEnumerator imageLoad(Image image)
    {
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = image.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        image.color = noColor;
        //����0.5��
        while (elapsedTime < 1.5f)
        {
            //���հٷֱȴ�0��1��ֵ
            float alpha = Mathf.Lerp(0, 1, elapsedTime / 1.5f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        image.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
    //�ı�����
    public IEnumerator imagetFade(Image image)
    {
        //����ʱ��
        float elapsedTime = 0f;
        //ȷ����ɫ�仯��ʱ��ڵ�
        Color startColor = image.color;
        Color noColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 1.5f);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        image.color = noColor;
    }
}
