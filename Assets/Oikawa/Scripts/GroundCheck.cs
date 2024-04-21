using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;


    //接地判定を返すメソッド
    //物理判定の更新毎に呼ぶ必要がある
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            Debug.Log("ground");
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        Debug.Log(isGround);
        return isGround;
    }

    private void OnTrigeerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == groundTag)
        {
            Debug.Log("if");
            isGroundEnter = true;
        }
    }

   private void OnCTrigeerStay2D(Collider2D collision)
    {
        Debug.Log("S");
        if (collision.gameObject.name == groundTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTrigeerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.name == groundTag)
        {
            isGroundExit = true;
        }
    }
}