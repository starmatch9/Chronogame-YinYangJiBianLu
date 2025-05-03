using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    //³¡¾°ÇÐ»»
    public void load(string name)
    {
        StartCoroutine(loadScene(name));
    }

    private IEnumerator loadScene(string name)
    {

        Debug.Log("ÇÐ»»³¡¾°ÖÐ");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(name);
    }
}
