using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndStop : MonoBehaviour
{
    public float speed;     // 移動速度
    private Animator animator;  // アニメーターコンポーネント取得用
    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネント取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // キャラの進行方向に移動する
        transform.position += speed * Time.deltaTime * transform.forward;
        // Z座標が20を越えたら停止
        if (Input.GetKeyUp(KeyCode.D)) 
        {             
            speed = 1;
            animator.SetBool("stop", true); // アニメーション切り替え
        }
        if (Input.GetKeyUp(KeyCode.A));
    }
}
