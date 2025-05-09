using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //选择音效
    public AudioClip sfx;
    //调节音量
    public float volume = 0.3f;

    private void Awake()
    {
        //此方法可以保证切换场景时不销毁
        DontDestroyOnLoad(gameObject);
    }

    public void sfxPlay()
    {
        //在摄像机位置附件播放
        Vector3 position = Camera.main.transform.position;
        //静态的播放方法
        AudioSource.PlayClipAtPoint(sfx, position, volume);
    }
}
