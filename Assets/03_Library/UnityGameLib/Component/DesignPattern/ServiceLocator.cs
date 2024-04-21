using CommonlyUsed;

namespace DesignPattern
{
    /// <summary>
    /// �T�[�r�X���P�[�^�N���X
    /// �T�[�r�X(�@�\��񋟂���N���X)�̂��肩�������Ă�������
    /// �v���O���������̎����Ɉˑ��������ɓ��삳�������Ƃ��ɗp���������@�̈��
    /// �f�U�C���p�^�[���̈��(ServiceLocator)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public static class ServiceLocator<T> where T : class
    {
        public static T Instance { get; private set; }

        //null����Ȃ����`�F�b�N
        public static bool IsValid() => Instance != null;

        //�C���X�^���X���O������ݒ肷���
        public static void Bind(T instance)
        {
            Instance = instance;
        }

        //�C���X�^���X��null�ɐݒ肷���
        public static void Unbind(T instance)
        {
            if (Instance == instance)
            {
                Instance = null;
            }
        }

        //�����I��null�ɂ���
        public static void Clear()
        {
            Instance = null;
        }
    }
}