using UnityEditor;
using UnityEngine;

public class BuildTools
{
    [MenuItem("Build/Clear PlayerPrefs & Run Build")]
    public static void ClearPlayerPrefsAndBuild()
    {
        // 清除所有PlayerPrefs数据
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("已清除所有PlayerPrefs数据");

        // 自动触发构建（可选）
        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            "Builds/MyGame.exe", // 替换为你的构建路径
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}