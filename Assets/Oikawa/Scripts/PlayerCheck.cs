using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("Stage");
    }

    void Update()
    {

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Instantiate(obj, new Vector3(40.0f, 0.0f, 0.0f), Quaternion.identity);
    //    }
    //}
}
