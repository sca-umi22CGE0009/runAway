using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    private Dogscript dog;
    //�t�@���̃I�u�W�F�N�g��
    //private GameObject fanA;

    bool boxCheck;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog").GetComponent<Dogscript>();

        //�q�G�����L�[��fan�̃I�u�W�F�N�g��
        //fanA = GameObject.Find("fanA");

        boxCheck = false;
    }

    void Update()
    {
        /*if (dog.TriggerCheck() && boxCheck)
        {
            //�t�@��������
            Destroy(fanA.gameObject);
        }*/

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCheck = true;
        }
        
        if(other.gameObject.tag == "Fun");
        {
            //Debug.Log("dog");
        }
    }
}
