using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningTextManager : MonoBehaviour
{
    public string[] texts; //テキストの表示
    public static int textNumber; //表示するテキストの番号
    string displayText;
    int textCharNumber; //表示する文字の数
    int displayTextSpeed;
    [SerializeField] int speed = 20; //文字送りスピード
    [SerializeField] int WaitTime;
    bool Return; //Enterが押されたかどうか判定

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
                if (textCharNumber != texts[textNumber].Length) //表示文字数が文字列の長さと異なるとき
                {
                    displayText = displayText + texts[textNumber][textCharNumber]; //n番目のn文字目を表示
                    textCharNumber = textCharNumber + 1; //表示する文字数を一文字ずつ増やす
                }
                else
                {
                    if (textNumber != texts.Length) //最後のテキストでないとき
                    {
                        if (Return == true) //Enterが押されたら
                        {
                            displayText = ""; //テキストを初期化
                            textCharNumber = 0; //表示する文字数を初期化
                            textNumber = textNumber + 1; //表示する文字列を次のものに変更
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