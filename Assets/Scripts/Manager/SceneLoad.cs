using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public MaskLoad ml;
    //³¡¾°ÇÐ»»
    public void load(string name)
    {
        StartCoroutine(loadScene(name));
    }

    private IEnumerator loadScene(string name)
    {
        yield return StartCoroutine(ml.load());
        SceneManager.LoadScene(name);
    }
}
