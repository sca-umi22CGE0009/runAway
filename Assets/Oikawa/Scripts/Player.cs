using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //インスペクターで設定する
    [SerializeField] float speed; // 速度
    [SerializeField] float gravity; // 重力
    [SerializeField] float jumpSpeed; // ジャンプ速度
    [SerializeField] float jumpHeight; // 高さ制限
    [SerializeField] float jumpLimitTime; // ジャンプ制限時間
    [SerializeField] GroundCheck ground; // 接地判定
    [SerializeField] GroundCheck head; // 頭判定
    [SerializeField] GameObject obj;
    

    //プライベート変数
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
        //コンポーネントのインスタンスを捕まえる
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 接地判定取得
        isGround = ground.IsGround();
        Debug.Log(ground.IsGround());
        isHead = head.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxisRaw("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;
        verticalKey = Input.GetAxisRaw("Vertical");


        if (gameObject.transform.position.x > 18.0f * a) 
        {
            Instantiate(obj, new Vector3(57.0f * a, 0.0f, 0.0f), Quaternion.identity);
            a++;
        }


        //ジャンプ
        Debug.Log(verticalKey);
        if (isGround)
        {
            Debug.Log("hoge");
            if (verticalKey > 0)
            {
                Debug.Log("jamp");
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; // ジャンプした位置を記録
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
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
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


        // 移動
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