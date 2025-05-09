using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouYu : MonoBehaviour
{
    public GameObject Yin;
    public GameObject Yang;

    public void changeYinYang()
    {
        if (Yin.activeSelf)
        {
            Yin.SetActive(false);
            Yang.SetActive(true);
        }
        else
        {
            Yin.SetActive(true);
            Yang.SetActive(false);
        }
    }


}
