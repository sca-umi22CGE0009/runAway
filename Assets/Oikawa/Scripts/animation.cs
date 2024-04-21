using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator anim = null;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        //if (collision.gameObject.CompareTag("Player"))
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", true);
        }
        else anim.SetBool("attack", false);

        //if (collision.gameObject.CompareTag("Dog"))
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("walk", false);
            anim.SetBool("scary", true);
        }
        else anim.SetBool("scary", false);

        //if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.P))
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("walk", false);
            anim.SetBool("down", true);
        }
        else anim.SetBool("down", false);
    }
}
