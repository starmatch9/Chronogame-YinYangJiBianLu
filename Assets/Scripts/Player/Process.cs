using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//������ʧ���������
public class Process : MonoBehaviour
{
    //��������������Σ�
    public Image process;
    //�������ļ����ٶ�
    public float speed = 0.5f;

    //�����������Ƭ����
    GameObject area = null;

    //�Ƿ�ʼ���ı�־
    bool fill = false;

    //�Ƿ�ת����ɫ�ı�־
    [HideInInspector]
    public bool change = false;

    //true��������Ϊ��ɫ��false��������Ϊ��ɫ
    [HideInInspector]
    public bool color = true;

    //������ȡ��ɫ����ɫ
    public ColorChange cc;

    private void Awake()
    {
        process = transform.GetComponent<Image>();
    }
    private void Update()
    {
        if (fill)
        {
            //���ٶȼ���
            process.fillAmount += Time.deltaTime * speed;
            if (process.fillAmount >= 1f)
            {
                //ͣ�ý�����
                process.fillAmount = 0f;
                if(area != null)
                {
                    change = true;
                    //���򽥱���ʧ
                    StartCoroutine(areaFade(area));
                }
            }
        }
    }
    //��⵽��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea"))
        {
            //������ɫΪ��ɫ
            color = false;

            area = collision.gameObject;
            process.color = Color.white;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea"))
        {
            //������ɫΪ��ɫ
            color = true;

            area = collision.gameObject;
            process.color = Color.black;
        }
    }
    //����������������ʱ������־��Ч
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea") /*&& cc.ren.material.color == Color.white*/)
        {
            fill = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea") /*&& cc.ren.material.color == Color.black*/)
        {
            fill = true;
        }
    }
    //��ȥ���򣬱�־ʧЧ����������գ�area���������ڵ�����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YinArea"))
        {
            fill = false;
            process.fillAmount = 0f;
            area = null;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("YangArea"))
        {
            fill = false;
            process.fillAmount = 0f;
            area = null;
        }
    }

    //������ʧЭ��
    private IEnumerator areaFade(GameObject area)
    {
        //����ʱ�䣬�����ۼ�
        float elapsedTime = 0f;
        Renderer renderer = area.GetComponent<Renderer>();
        Color startColor = area.GetComponent<Renderer>().material.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        //���������ײ��ʧЧ
        Collider2D col = area.GetComponent<Collider2D>();
        col.enabled = false;

        while (elapsedTime < 2.0f)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / 2.0f);
            renderer.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            //�ȴ���һ֡
            yield return null;
        }
        renderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        //������ɺ�������ʧ
        area.SetActive(false);
    }
}
