using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class ItemScript : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefab;
    int number;
    [SerializeField] private float distanceMin;
    [SerializeField] private float distanceMax;
    private float distance;
    [SerializeField] private GameObject charaA;
    [SerializeField] private GameObject charaB;

    float chara_x;
    private int selectChara;
    [SerializeField] float y = -3.05f;

    [SerializeField] private float countTime = 3.5f;
    float timer;

    void Start()
    {
        timer = countTime;
        selectChara = SelectSceneManager.selectCharacter;

        //charaの座標取得
        switch (selectChara)
        {
            case 1:
                chara_x = charaA.transform.position.x;
                break;
            case 2:
                chara_x = charaB.transform.position.x;
                break;
            default:
                chara_x = charaA.transform.position.x;
                break;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //乱数
            distance = Random.Range(distanceMin, distanceMax);
            number = Random.Range(0, itemPrefab.Length);
            Instantiate(itemPrefab[number], new Vector3(distance + chara_x, y, 0), transform.rotation);
            //初期化
            timer = countTime;
        }
    }
}
