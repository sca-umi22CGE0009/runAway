using System.Collections;
using System.Collections.Generic;
using CommonlyUsed;
using UnityEngine;
using UnityEngine.UI;
using DesignPattern;

namespace GameManager
{
    public interface ISceneManager
    {
        void SceneLog(SceneManager sLib);
        void SceneLoadingAsync(string str);
        IEnumerator FadeWait(string str);
        IEnumerator LoadScene(string str);
        IEnumerator LoadingWait(AsyncOperation async, string str);
    }

    public class SceneManager : Singleton<SceneManager>,ISingleton,ISceneManager
    {
        [SerializeField, Header("LoadingScreen")] GameObject obj;
        [SerializeField] Slider slider;
        [SerializeField] Text text;
        [SerializeField] Fade fade;
        [SerializeField] FadeImage fadeImage;
        [SerializeField, Header("Fade���鎞��")] float fadeTime = 0;
        [SerializeField, Header("���ׂĂ�log�\��:")] bool log0 = false;
        [SerializeField, Header("Scene�̑���:")] bool log1 = false;
        [SerializeField, Header("Scene�̑���:")] bool log2 = false;
        bool waitCheck = true;


        /// <summary>
        /// �V�[���̏�ԕ\�����O
        /// ����(SceneManagerLib SceneManagerLib�N���X���p����������)
        /// </summary>
        /// <param name="sLib">SceneManagerLib�N���X���p����������</param>
        public void SceneLog(SceneManager sLib)
        {
            if (log0 == false) { return; }

            if (log1 == true)
            {
                string str = StringComponent.AddString("���݃��[�h����Ă���V�[���̑���", UnityEngine.SceneManagement.SceneManager.sceneCount.ToString());
                Debug.Log(str);
            }

            if (log2 == true)
            {
                string str1 = StringComponent.AddString("�r���h�ݒ�̃V�[����: ", UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings.ToString());
                Debug.Log(str1);
            }
        }

        /// <summary>
        /// �񓯊��ŃV�[����J�ڂ���֐�
        /// �V�[���J�ڒ��͎����I�Ƀ��[�f�B���O��ʂ��͂��݂܂��B
        /// ����(string �ړ��������V�[����)
        /// </summary>
        /// <param name="str">�ړ��������V�[����</param>
        public void SceneLoadingAsync(string str)
        {
            fade.FadeIn(fadeTime, () => obj.SetActive(true));
            StartCoroutine(FadeWait(str));
        }

        //fade�I����Loading��ʂɈړ�
        public IEnumerator FadeWait(string str)
        {
            yield return new WaitUntil(() => fadeImage.Range == 1f);
            fade.FadeOut(fadeTime, () => StartCoroutine(LoadScene(str)));
        }

        //�V�[���̓ǂݍ��ݑ҂�
        public IEnumerator LoadScene(string str)
        {
            yield return null;

            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(str);
            async.allowSceneActivation = false;

            while (!async.isDone)
            {
                slider.value = async.progress;

                if (async.progress >= 0.9f)
                {
                    text.text = "�ǂݍ��݊���";
                    if (waitCheck) StartCoroutine(LoadingWait(async, str));
                    waitCheck = false;
                }
                yield return null;
            }
        }

        //Loading�I����J��
        public IEnumerator LoadingWait(AsyncOperation async, string str)
        {
            yield return new WaitForSeconds(2f);//���[�f�B���O����
            Debug.Log(StringComponent.AddString(StringComponent.AddString("<color=orange><size=13><b>",UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "</b></size></color><color=lightblue><size=13><b>�V�[������</b></size></color>"), "<color=orange><size=13><b>", str, "</b></size></color><color=lightblue><size=13><b>�V�[���֑J��</b></size></color>"));

            fade.FadeIn(fadeTime, () => async.allowSceneActivation = true);
        }
    }
}