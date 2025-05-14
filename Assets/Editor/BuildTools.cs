using UnityEditor;
using UnityEngine;

public class BuildTools
{
    [MenuItem("Build/Clear PlayerPrefs & Run Build")]
    public static void ClearPlayerPrefsAndBuild()
    {
        // �������PlayerPrefs����
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("���������PlayerPrefs����");

        // �Զ�������������ѡ��
        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            "Builds/MyGame.exe", // �滻Ϊ��Ĺ���·��
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}