using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharaSelect : MonoBehaviour
{
    [SerializeField]
    GameObject mainCharaA;

    [SerializeField]
    GameObject mainCharaB;

    int selectCharacter = SelectSceneManager.selectCharacter;

    void Start()
    {
        //デバッグ用
        /*{
            selectCharacter = 1;
        }*/

        switch(selectCharacter)
        {
            case 1:
                mainCharaA.SetActive(true);
                mainCharaB.SetActive(false);
            break;
            case 2:
                mainCharaA.SetActive(false);
                mainCharaB.SetActive(true);
            break;
        }
    }

    void Update()
    {
        
    }
}
