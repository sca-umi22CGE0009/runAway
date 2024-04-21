using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    privateÅ@float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.localPosition;

        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed;
        }
        transform.localPosition = position;
    }
}
