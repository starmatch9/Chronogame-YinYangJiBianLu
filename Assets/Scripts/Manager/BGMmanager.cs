using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    //这个存放着游戏是否结束的信息
    //时间线：场景开始后3秒淡入，区域数量等于0时淡出
    public AreaNumManager areaNumManager;

    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(load());
    }

    private void Update()
    {
        if (areaNumManager.areaNum() == 0)
        {
            StartCoroutine(fade());
        }
    }
    //淡入
    private IEnumerator load()
    {
        //设置开始音量为0
        audioSource.volume = 0f;

        //等3秒文字时间后开始播放
        yield return new WaitForSeconds(3f);
        audioSource.Play();
        //累计时间
        float elapsed = 0;
        while (elapsed < 2f)
        {
            audioSource.volume = Mathf.Lerp(0f, 0.05f, elapsed / 2f);
            //增量
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0.05f;
    }
    //淡出
    private IEnumerator fade()
    {
        //定为标准的0.2
        audioSource.volume = 0.05f;
        //累计时间
        float elapsed = 0;
        while (elapsed < 1f)
        {
            audioSource.volume = Mathf.Lerp(0.05f, 0f, elapsed / 1f);
            //增量
            elapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = 0f;
    }
}
