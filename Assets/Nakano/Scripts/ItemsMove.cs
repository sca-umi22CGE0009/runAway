using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMove : MonoBehaviour
{
    [SerializeField] float Speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }
}
