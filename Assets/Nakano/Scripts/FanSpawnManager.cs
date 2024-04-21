using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawnManager : MonoBehaviour
{
    public GameObject[] fanPrefabA;
    public GameObject[] fanPrefabB;
    int number;
    [SerializeField] private float distanceMin;
    [SerializeField] private float distanceMax;
    private float distance;
    private float time;
    [SerializeField] private float timeInterval;

    int selectCharacter = SelectSceneManager.selectCharacter;

    void Start()
    {
        time = timeInterval;
        selectCharacter = 1; //Debug
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            if(selectCharacter == 1)
            {
                distance = Random.Range(distanceMin, distanceMax);
                number = Random.Range(0, fanPrefabA.Length);
                Instantiate(fanPrefabA[number], new Vector3(distance, -2.3f, 0), transform.rotation);
                time = timeInterval;
            }
            if(selectCharacter == 2)
            {
                distance = Random.Range(distanceMin, distanceMax);
                number = Random.Range(0, fanPrefabB.Length);
                Instantiate(fanPrefabB[number], new Vector3(distance, -2.3f, 0), transform.rotation);
                time = timeInterval;
            }
        }
    }
}
