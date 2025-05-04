using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public MaskLoad ml;
    //场景切换
    public void load(string name)
    {
        StartCoroutine(loadScene(name));
    }

    private IEnumerator loadScene(string name)
    {
        //加载后在进行切换
        yield return StartCoroutine(ml.load());
        SceneManager.LoadScene(name);
    }
}
