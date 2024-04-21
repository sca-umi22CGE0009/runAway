using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    
        public interface ISingleton
        {
            bool DestroyTragetGameObject { get; }
            void Init();
            void OnDestroy();
            void OnRelease();
        }

        /// <summary>
        /// �V���O���g���N���X
        /// �N���X�̃C���X�^���X����ɐ�������
        /// �O���[�o���ȃA�N�Z�X�|�C���g��񋟂���
        /// �f�U�C���p�^�[���̈��(Singleton)
        /// </summary>(���pURL�j
        /// https://marunaka-blog.com/cshap-singleton/5433/
        public class Singleton<T> : MonoBehaviour, ISingleton where T : Singleton<T>
        {
            public virtual bool DestroyTragetGameObject => false;
            public static T Instance { get; private set; } = null;

            ///<summary>
            ///Singleton���L�����ǂ���
            /// </summary>
            public static bool IsValid() => Instance != null;

            private void Awake()
            {
                if (Instance == null)
                {
                    Instance = this as T;
                    Instance.Init();
                    return;
                }
                if (DestroyTragetGameObject)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(this);
                }
            }

            ///<summary>
            ///�h���N���X�p��Awake
            /// </summary>
            public virtual void Init() { }

            public void OnDestroy()
            {
                if (Instance == this)
                {
                    Instance = null;
                }
                OnRelease();
            }

            public virtual void OnRelease() { }
        }
    
}