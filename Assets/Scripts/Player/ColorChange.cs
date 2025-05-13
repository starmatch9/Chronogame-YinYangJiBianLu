using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //�鿴�������Ƿ����
    public Process process;

    public Color color = Color.white;

    public SFX sfx;

    //��������
    public GouYu GouYu1;
    public GouYu GouYu2;

    //������Ⱦ��
    [HideInInspector]
    public SpriteRenderer ren;

    //�������ͼ��
    public Sprite YangYu;
    public Sprite YinYu;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
        //��ʼ��Ϊ����
        ren.sprite = YangYu;
    }
    private void Update()
    {
        if (process.change)
        {
            sfx.sfxPlay();
            process.change = false;
            if (ren.sprite == YangYu)
            {
                //����Ϊ��ɫʱ������������ɫ��ҪҲ�ǰף��ٿ�����2����û��
                //�����ˣ�ȡ������ת��Ϊ�ڣ�û�������
                //����Ҫ�Ǻ�ɫ�������ˣ�ȡ�����û����ת��Ϊ��
                if (process.color)
                {
                    if (GouYu2.transform.gameObject.activeSelf)
                    {
                        GouYu2.transform.gameObject.SetActive(false);
                        change();
                        GouYu1.changeYinYang();
                        GouYu2.changeYinYang();
                    }
                    else
                    {
                        GouYu2.transform.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (GouYu2.transform.gameObject.activeSelf)
                    {
                        GouYu2.transform.gameObject.SetActive(false);
                    }
                    else
                    {
                        change();
                        GouYu1.changeYinYang();
                        GouYu2.changeYinYang();
                    }
                }


            }
            else if(ren.sprite == YinYu)
            {
                //����Ϊ��ɫʱ������������ɫ
                //Ҫ�ǰ�ɫ�������ˣ�ȡ�����û���ת����ɫ
                //Ҫ�Ǻ�ɫ�������ˣ�ȡ������ת����ɫ��û�������
                if (process.color)
                {
                    if (GouYu2.transform.gameObject.activeSelf)
                    {
                        GouYu2.transform.gameObject.SetActive(false);
                    }
                    else
                    {
                        change();
                        GouYu1.changeYinYang();
                        GouYu2.changeYinYang();
                    }
                }
                else
                {
                    if (GouYu2.transform.gameObject.activeSelf)
                    {
                        GouYu2.transform.gameObject.SetActive(false);
                        change();
                        GouYu1.changeYinYang();
                        GouYu2.changeYinYang();
                    }
                    else
                    {
                        GouYu2.transform.gameObject.SetActive(true);
                    }
                }

            }
            //process.change = false;
            //change();
            //GouYu1.changeYinYang();
            //GouYu2.changeYinYang();
        }
    }
    //�ı���ɫ�ķ���
    private void change()
    {
        if(ren.sprite == YangYu)
        {
            ren.sprite = YinYu;
        }
        else
        {
            ren.sprite = YangYu;
        }
    }
}
