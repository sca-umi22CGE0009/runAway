using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    private Image BackGround;
    public Sprite[] m_BackGround;

    int selectCharacter = SelectSceneManager.selectCharacter;

    void SelectA()
    {
        BackGround.sprite = m_BackGround[0];
    }

    void SelectB()
    {
        BackGround.sprite = m_BackGround[1];
    }

    void Start()
    {
        BackGround = GetComponent<Image>();
    }

    void Update()
    {
        switch (selectCharacter)
        {
            case 1:
                SelectA();
                break;
            case 2:
                SelectB();
                break;
        }
    }
}
