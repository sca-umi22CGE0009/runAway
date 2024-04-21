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
    //[SerializeField] private GameObject chara;
    float chara_x;
    private int selectChara;

    [SerializeField] float y;
    private void Charas()
    {
        //charaÇÃç¿ïWéÊìæ
        //chara_x = chara.transform.position.x;
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

        //óêêî
        distance = Random.Range(distanceMin, distanceMax);
        number = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[number], new Vector3(distance + chara_x, y, 0), transform.rotation);
    }

    void Start()
    {
        selectChara = SelectSceneManager.selectCharacter;
        StartCoroutine("DogCount");
    }

    void Update()
    {
    }

    IEnumerator DogCount()
    {
        for (int count = 0; count < 5; count++)
        {
            yield return new WaitForSeconds(3.5f);
            Charas();
        }
    }
}
