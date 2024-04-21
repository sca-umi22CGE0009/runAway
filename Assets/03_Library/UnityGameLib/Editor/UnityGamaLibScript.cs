#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.IO;
using UnityEditor;

public class UnityGamaLibScript : EditorWindow
{
    string script = "";
    string className = "";
    // @""�Ƃ��邱�ƂŁA�����s��������
    // �����u"�v�́u""�v�Ƃ��ď����܂�
    private const string CODE =
@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class Noname : MonoBehaviour,IUpdateManager
{
    

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }
}
    ";



    [MenuItem("UnityGameLib/TemplateCode/Standard")]
    [MenuItem("Assets/Create/UnityGameLib/TemplateCode/Standard")]
    private static void ShowWindow()
    {
        UnityGamaLibScript window = (UnityGamaLibScript)GetWindow(typeof(UnityGamaLibScript));
        window.titleContent = new GUIContent("��ScriptCreator");
    }

    private void OnGUI()
    {
        GUILayout.Label("ScriptName");
        className = EditorGUILayout.TextArea(className, GUILayout.Height(20));

        if (GUILayout.Button("ScriptCreate"))
        {
            Debug.Log(className);
            script = CODE.Replace("Noname",className);
            Generate(className,script);
        }
    }

    private static void Generate(string scriptName,string script)
    {
        // �쐬����A�Z�b�g�̃p�X
        string filePath = GetCurrentDirectory()+"/"+scriptName+".cs";

        // �������O(�p�X)���d�����Ă����ꍇ�ɁA�����Ō���ɁuSample1.cs�v�݂������������Ă����
        string assetPath = AssetDatabase.GenerateUniqueAssetPath(filePath);

        // �A�Z�b�g(.cs)���쐬����
        File.WriteAllText(assetPath,script);

        // �ύX���������A�Z�b�g���C���|�[�g����(UnityEditor�̍X�V)
        AssetDatabase.Refresh();

    }

    /// <summary>
    /// �Q�lURL
    /// https://qiita.com/r-ngtm/items/13d609cbd6a30e39f83a
    /// </summary>
    /// <returns></returns>
    static string GetCurrentDirectory()
    {
        BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
        Assembly asm = Assembly.Load("UnityEditor.dll");
        System.Type typeProjectBrowser = asm.GetType("UnityEditor.ProjectBrowser");
        EditorWindow projectBrowserWindow = GetWindow(typeProjectBrowser);
        return (string)typeProjectBrowser.GetMethod("GetActiveFolderPath", flag).Invoke(projectBrowserWindow, null);
    }

}

#endif
