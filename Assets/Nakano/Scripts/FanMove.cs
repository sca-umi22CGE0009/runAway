using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanMove : MonoBehaviour
{
    [SerializeField] private float speed;
    Animator anim = null;
    bool isWalk, isAttack, isScary, isDown;

    int selectCharacter = SelectSceneManager.selectCharacter;

    [SerializeField] GameObject playerA;
    //[SerializeField] GameObject playerB;
    float posP, pos;

    void Start()
    {
        anim = GetComponent<Animator>();
        isWalk = true;
        isAttack = false;
        isScary = false;
        isDown = false;

        selectCharacter = 1;

/*        switch (selectCharacter)
        {
            case 1: 
                posP = playerA.GetComponent<Transform>().position.x;
            break;
            case 2:
                posP = playerB.GetComponent<Transform>().position.x;
            break;
        }*/

        pos = this.GetComponent<Transform>().position.x;
    }

    void Update()
    {
        if(isWalk)
        {
            anim.SetBool("walk", true);
        }

        //transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime * 0.3f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(speed * Time.deltaTime * 1.5f, 0, 0);
        }

        else { transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); }

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

        if(this.GetComponent<Transform>().position.x < 5)
        {
            isWalk = false;
            isAttack = true;
        }
        if(isAttack && !isScary)
        {
            anim.SetBool("attack", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Attack")
        {
            //gameObject.SetActive(false);
            isWalk = false;
            isDown = true;
            anim.SetBool("down", true);
            this.tag = "DamageFun";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DogAttack")
        {
            Debug.Log("Dog");
            isWalk = false;
            isAttack = false;
            isScary = true;
            anim.SetBool("scary", true);
            this.tag = "DamageFun";
        }
    }
}
