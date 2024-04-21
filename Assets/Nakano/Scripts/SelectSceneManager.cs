using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneManager : MonoBehaviour
{
    //主人公A
    [SerializeField] private GameObject FlameA1; //フレーム
    [SerializeField] private GameObject FlameA2;
    [SerializeField] private GameObject CharacterA1; //立ち絵
    [SerializeField] private GameObject CharacterA2;
    [SerializeField] private GameObject ExplanationA; //キャラ説明文

    //主人公B
    [SerializeField] private GameObject FlameB1;
    [SerializeField] private GameObject FlameB2;
    [SerializeField] private GameObject CharacterB1;
    [SerializeField] private GameObject CharacterB2;
    [SerializeField] private GameObject ExplanationB;

    //確認ウィンドウ
    [SerializeField] private GameObject ConfirmationWindow; //確認ウィンドウ
    [SerializeField] private GameObject ConfirmationText;　//確認テキスト
    public static int selectCharacter; //どちらのキャラクターを選択したか

    int select = 0;

    void First() //初期状態
    {
        select = 0;
        
        FlameA1.SetActive(true);
        FlameA2.SetActive(false);
        CharacterA1.SetActive(true);
        CharacterA2.SetActive(false);
        ExplanationA.SetActive(false);

        FlameB1.SetActive(true);
        FlameB2.SetActive(false);
        CharacterB1.SetActive(true);
        CharacterB2.SetActive(false);
        ExplanationB.SetActive(false);
    }
    
    void SelectA() //主人公Aを選択したとき
    {
        FlameA1.SetActive(false);
        FlameA2.SetActive(true);
        CharacterA1.SetActive(false);
        CharacterA2.SetActive(true);
        ExplanationA.SetActive(true);

        FlameB1.SetActive(true);
        FlameB2.SetActive(false);
        CharacterB1.SetActive(true);
        CharacterB2.SetActive(false);
        ExplanationB.SetActive(false);

        selectCharacter = 1;
    }

    void SelectB() //主人公Bを選択したとき
    {
        FlameA1.SetActive(true);
        FlameA2.SetActive(false);
        CharacterA1.SetActive(true);
        CharacterA2.SetActive(false);
        ExplanationA.SetActive(false);

        FlameB1.SetActive(false);
        FlameB2.SetActive(true);
        CharacterB1.SetActive(false);
        CharacterB2.SetActive(true);
        ExplanationB.SetActive(true);

        selectCharacter = 2;
    }

    void selectDecide() //確認Window表示
    {
        ConfirmationWindow.SetActive(true);
    }
    
    void Start()
    {
        select = 0;
    }

    void Update()
    {
        if (select > 2)
        {
            select = 1;
        }

        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A)))
        {
            select += 1;
        }

        switch(select)
        {
            case 0:
                First();
            break;
            case 1:
                SelectA();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    selectDecide();
                }
            break;
            case 2:
                SelectB();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    selectDecide();
                }
                break;
        }

        Text confirmation_text = ConfirmationText.GetComponent<Text>();
        switch (selectCharacter)
        {
            case 1:
                confirmation_text.text = "メンちゃん でOK?";
                break;
            case 2:
                confirmation_text.text = "ローラ でOK?";
                break;
        }
    }
}
