using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    GameObject playerObj;
    Player player;
    Transform playerTransform;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerTransform = playerObj.transform;
    }

    
    void LateUpdate()
    {
        // MoveCamera�Ăяo��
        MoveCamera();
    }

    void MoveCamera()
    {
        // �������̂ݒǏ]
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
