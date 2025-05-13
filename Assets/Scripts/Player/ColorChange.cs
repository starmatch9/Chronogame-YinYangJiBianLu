using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //查看进度条是否结束
    public Process process;

    public Color color = Color.white;

    public SFX sfx;

    //两个勾玉
    public GouYu GouYu1;
    public GouYu GouYu2;

    //这是渲染器
    [HideInInspector]
    public SpriteRenderer ren;

    //两条鱼的图像
    public Sprite YangYu;
    public Sprite YinYu;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
        //初始化为阳鱼
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
                //物体为白色时，检测区域的颜色，要也是白，再看勾玉2激活没有
                //激活了，取消激活转化为黑，没激活，激活
                //区域要是黑色，激活了，取消激活，没激活转化为黑
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
                //物体为黑色时，检测区域的颜色
                //要是白色，激活了，取消激活，没激活，转化颜色
                //要是黑色，激活了，取消激活转化颜色，没激活，激活
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
    //改变颜色的方法
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
