using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaScript : MonoBehaviour
{
    [SerializeField]
    private GameObject A = null; //アイドルA
    [SerializeField]
    private GameObject B = null; //アイドルB

    private int selectChara = SelectSceneManager.selectCharacter;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("通った！");
        if (selectChara == 1)
        {
            A.gameObject.SetActive(true);
            B.gameObject.SetActive(false);
        }
        if (selectChara == 2)
        {
            A.gameObject.SetActive(false);
            B.gameObject.SetActive(true);
        }
    }
}
