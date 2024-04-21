using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�C���X�y�N�^�[�Őݒ肷��
    [SerializeField] float speed; // ���x
    [SerializeField] float gravity; // �d��
    [SerializeField] float jumpSpeed; // �W�����v���x
    [SerializeField] float jumpHeight; // ��������
    [SerializeField] float jumpLimitTime; // �W�����v��������
    [SerializeField] GroundCheck ground; // �ڒn����
    [SerializeField] GroundCheck head; // ������
    [SerializeField] GameObject obj;
    

    //�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;
    private float dashTime, jumpTime;
    private float beforeKey;
    private int a = 1;
    private float verticalKey;

    void Start()
    {
        //�R���|�[�l���g�̃C���X�^���X��߂܂���
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // �ڒn����擾
        isGround = ground.IsGround();
        Debug.Log(ground.IsGround());
        isHead = head.IsGround();

        //�L�[���͂��ꂽ��s������
        float horizontalKey = Input.GetAxisRaw("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;
        verticalKey = Input.GetAxisRaw("Vertical");


        if (gameObject.transform.position.x > 18.0f * a) 
        {
            Instantiate(obj, new Vector3(57.0f * a, 0.0f, 0.0f), Quaternion.identity);
            a++;
        }


        //�W�����v
        Debug.Log(verticalKey);
        if (isGround)
        {
            Debug.Log("hoge");
            if (verticalKey > 0)
            {
                Debug.Log("jamp");
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; // �W�����v�����ʒu���L�^
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //������L�[�������Ă��邩
            bool pushUpKey = verticalKey > 0;
            //���݂̍�������ׂ鍂����艺��
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���ĂȂ���
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }


        // �ړ�
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}