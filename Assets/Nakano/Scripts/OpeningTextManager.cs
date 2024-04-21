using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningTextManager : MonoBehaviour
{
    public string[] texts; //�e�L�X�g�̕\��
    public static int textNumber; //�\������e�L�X�g�̔ԍ�
    string displayText;
    int textCharNumber; //�\�����镶���̐�
    int displayTextSpeed;
    [SerializeField] int speed = 20; //��������X�s�[�h
    [SerializeField] int WaitTime;
    bool Return; //Enter�������ꂽ���ǂ�������

    bool isStop;

    private void Start()
    {
        textNumber = 0;
        textCharNumber = 0;
        displayTextSpeed = 0;
    }

    void Update()
    {
        isStop = FadeManager.isStop;

        if (!isStop)
        {
            displayTextSpeed++;
            if (displayTextSpeed % speed == 0)
            {
                if (textCharNumber != texts[textNumber].Length) //�\����������������̒����ƈقȂ�Ƃ�
                {
                    displayText = displayText + texts[textNumber][textCharNumber]; //n�Ԗڂ�n�����ڂ�\��
                    textCharNumber = textCharNumber + 1; //�\�����镶�������ꕶ�������₷
                }
                else
                {
                    if (textNumber != texts.Length) //�Ō�̃e�L�X�g�łȂ��Ƃ�
                    {
                        if (Return == true) //Enter�������ꂽ��
                        {
                            displayText = ""; //�e�L�X�g��������
                            textCharNumber = 0; //�\�����镶������������
                            textNumber = textNumber + 1; //�\�����镶��������̂��̂ɕύX
                        }
                    }
                }
            }

            this.GetComponent<Text>().text = displayText;
            Return = false;

            if (Input.GetKey(KeyCode.Return))
            {
                Return = true;
            }

        }
        else
        {
            displayText = "";
        }

        if (textNumber >= texts.Length)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("ExplanationScene");
            }
        }
    }
}