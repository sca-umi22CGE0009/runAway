using UnityEngine;
using DesignPattern;
using System.Collections;

namespace GameManager
{

    public interface ISoundManager
    {
        void PlayBGM(int bgmManager,bool loopCheck);
        void PlaySE(int seNumber);
    }

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : Singleton<SoundManager> ,ISoundManager
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField, Header("fade�̎���")] float fadeTime; 
        [SerializeField] AudioClip[] soundBGM;
        [SerializeField] AudioClip[] soundSE;

        WaitForSeconds fadeWaitTime = null;

        private void Start()
        {
            fadeWaitTime = new WaitForSeconds(fadeTime);
        }

        /// <summary>
        /// �o�b�N�O���E���h�Đ�
        /// ����(int BGM�z��̔ԍ�)
        /// </summary>
        /// <param name="bgmNumber">BGM�z��̔ԍ�</param>
        public void PlayBGM(int bgmNumber,bool loopCheck)
        {
            audioSource.clip = soundBGM[bgmNumber];
            audioSource.Play();
            audioSource.loop = loopCheck;
        }

        public void FadeIn_BGM()
        {
            StartCoroutine(FadeIn());
        }

        public void FadeOut_BGM(float volumeMax)
        {
            StartCoroutine(FadeOut(volumeMax));
        }

        /// <summary>
        /// ���ʉ�(se)�Đ�
        /// ����(int SE�z��̔ԍ�)
        /// </summary>
        /// <param name="seNumber">SE�z��̔ԍ�</param>
        public void PlaySE(int seNumber)
        {
            audioSource.PlayOneShot(soundSE[seNumber]);
        }

        private IEnumerator FadeIn()
        {
            while (audioSource.volume > 0f)
            {
                yield return fadeWaitTime;
                audioSource.volume -= 0.01f;
            }
        }

        private IEnumerator FadeOut(float volumeMax)
        {
            while (audioSource.volume < volumeMax)
            {
                yield return fadeWaitTime;
                audioSource.volume += 0.01f;
            }
        }
    }
}
