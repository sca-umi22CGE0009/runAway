

using UnityEngine;

// CanvasGroup�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�A�A�^�b�`
[RequireComponent(typeof(CanvasGroup))]
public class ChangeAlpha : MonoBehaviour
{
    // �t�F�[�h�����鎞�Ԃ�ݒ�
    [SerializeField]
    [Tooltip("�t�F�[�h�����鎞��(�b)")]
    private float fadeTime = 1f;
    // �o�ߎ��Ԃ��擾
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // ���̃Q�[���I�u�W�F�N�g��CanvasGroup�R���|�[�l���g���擾���āA
        // alpha�l��0(�����j�ɂ���B
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ����Z
        timer += Time.deltaTime;
        // �o�ߎ��Ԃ�fadeTime�Ŋ������l��alpha�ɓ����
        // ��alpha�l��1(�s����)���ő�B
        this.gameObject.GetComponent<CanvasGroup>().alpha = timer / fadeTime;
    }
}

