using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndStop : MonoBehaviour
{
    public float speed;     // �ړ����x
    private Animator animator;  // �A�j���[�^�[�R���|�[�l���g�擾�p
    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�擾
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �L�����̐i�s�����Ɉړ�����
        transform.position += speed * Time.deltaTime * transform.forward;
        // Z���W��20���z�������~
        if (Input.GetKeyUp(KeyCode.D)) 
        {             
            speed = 1;
            animator.SetBool("stop", true); // �A�j���[�V�����؂�ւ�
        }
        if (Input.GetKeyUp(KeyCode.A));
    }
}
