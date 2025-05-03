using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    //�����л�
    public void load(string name)
    {
        StartCoroutine(loadScene(name));
    }

    private IEnumerator loadScene(string name)
    {

        Debug.Log("�л�������");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(name);
    }
}
