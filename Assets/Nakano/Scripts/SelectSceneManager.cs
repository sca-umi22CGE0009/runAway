using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneManager : MonoBehaviour
{
    //��l��A
    [SerializeField] private GameObject FlameA1; //�t���[��
    [SerializeField] private GameObject FlameA2;
    [SerializeField] private GameObject CharacterA1; //�����G
    [SerializeField] private GameObject CharacterA2;
    [SerializeField] private GameObject ExplanationA; //�L����������

    //��l��B
    [SerializeField] private GameObject FlameB1;
    [SerializeField] private GameObject FlameB2;
    [SerializeField] private GameObject CharacterB1;
    [SerializeField] private GameObject CharacterB2;
    [SerializeField] private GameObject ExplanationB;

    //�m�F�E�B���h�E
    [SerializeField] private GameObject ConfirmationWindow; //�m�F�E�B���h�E
    [SerializeField] private GameObject ConfirmationText;�@//�m�F�e�L�X�g
    public static int selectCharacter; //�ǂ���̃L�����N�^�[��I��������

    int select = 0;

    void First() //�������
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
    
    void SelectA() //��l��A��I�������Ƃ�
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

    void SelectB() //��l��B��I�������Ƃ�
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

    void selectDecide() //�m�FWindow�\��
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
                confirmation_text.text = "��������� ��OK?";
                break;
            case 2:
                confirmation_text.text = "���[�� ��OK?";
                break;
        }
    }
}
