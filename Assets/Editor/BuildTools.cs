using UnityEditor;
using UnityEngine;

public class BuildTools
{
    [MenuItem("Build/Clear PlayerPrefs & Run Build")]
    public static void ClearPlayerPrefsAndBuild()
    {
        // 清除所有PlayerPrefs数据
        PlayerPrefs.DeleteKey("video");
        PlayerPrefs.DeleteKey("Yin-Yang-1");
        PlayerPrefs.DeleteKey("Yin-Yang-2");
        PlayerPrefs.DeleteKey("Yin-Yang-3");
        PlayerPrefs.DeleteKey("Yin-Yang-4");
        PlayerPrefs.DeleteKey("Yin-Yang-5");
        PlayerPrefs.DeleteKey("Yin-Yang-6");

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("已清除所有PlayerPrefs数据");
    }
}