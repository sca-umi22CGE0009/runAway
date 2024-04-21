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
        // MoveCameraåƒÇ—èoÇµ
        MoveCamera();
    }

    void MoveCamera()
    {
        // â°ï˚å¸ÇÃÇ›í«è]
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
