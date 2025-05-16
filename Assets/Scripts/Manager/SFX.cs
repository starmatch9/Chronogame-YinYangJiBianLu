using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    //选择音效
    public AudioClip sfx;
    //调节音量
    float volume = 0.1f;

    public void sfxPlay()
    {
        //在摄像机位置附件播放
        Vector3 position = Camera.main.transform.position;
        //静态的播放方法
        AudioSource.PlayClipAtPoint(sfx, position, volume);
    }
}
