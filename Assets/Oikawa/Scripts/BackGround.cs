using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < -13.8f)
        {
            transform.position = new Vector3(13.8f, 0, 0);
        }
    }
}
