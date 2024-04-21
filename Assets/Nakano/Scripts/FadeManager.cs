using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    //キャラクター
    [SerializeField] private GameObject CharacterA;
    [SerializeField] private GameObject CharacterB;

    //セリフ
    [SerializeField] private GameObject SerifA;
    [SerializeField] private GameObject SerifB;

    //テキストボックス
    [SerializeField] private GameObject TextBoxA;
    [SerializeField] private GameObject TextBoxB;

    //名前
    [SerializeField] private GameObject NameTextA;
    [SerializeField] private GameObject NameTextB;

    //フェードイン・フェードアウト
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    Image fadeAlphaA, fadeAlphaB;
    float alphaA, alphaB;
    public static bool isFadeout;
    public static bool isFadein;

    //移動
    [SerializeField] private float moveSpeed;

    public static bool isChange = false;
    public static bool isStop = false;
    int textNumber;
    int selectCharacter = SelectSceneManager.selectCharacter;

    void SelectA()
    {
        CharacterA.SetActive(true);
        SerifA.SetActive(true);
        TextBoxA.SetActive(true);
        NameTextA.SetActive(true);

        fadeAlphaA = CharacterA.GetComponent<Image>();
        alphaA = fadeAlphaA.color.a;
        fadeAlphaA.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    }

    void SelectB()
    {
        CharacterB.SetActive(true);
        SerifB.SetActive(true);
        TextBoxB.SetActive(true);
        NameTextB.SetActive(true);

        fadeAlphaB = CharacterB.GetComponent<Image>();
        alphaB = fadeAlphaB.color.a;
        fadeAlphaB.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    }

    void Start()
    {
        CharacterA.SetActive(false);
        CharacterB.SetActive(false);
        SerifA.SetActive(false);
        SerifB.SetActive(false);
        TextBoxA.SetActive(false);
        TextBoxB.SetActive(false);
        NameTextA.SetActive(false);
        NameTextB.SetActive(false);

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

    void Update()
    {
        textNumber = OpeningTextManager.textNumber;
        switch (textNumber)
        {
            case 1:
            case 2:
            case 3:
            case 6:
            case 7:
               if ((Input.GetKeyDown(KeyCode.Return)) && ((alphaA >= 1) || (alphaB >= 1)))
               {
                   isFadeout = true;
               }
                break;
            }

        switch (selectCharacter)
        {
            case 1:
                if (isFadeout)
               {
                    FadeOutA();
                }
                if (isFadein)
                {
                    FadeInA();
                }
                break;
            case 2:
                if (isFadeout)
                {
                    FadeOutB();
                }
                if (isFadein)
                {
                    FadeInB();
                }
                break;
            }

        if ((alphaA < 1.0f && alphaA > 0.0f) || (alphaB < 1.0f && alphaB > 0.0f))
        {
            isStop = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(textNumber);
            Debug.Log(isStop);
        }
    } 

    void FadeOutA()
    {
        isStop = true;
        alphaA -= fadeOutSpeed * Time.deltaTime;
        fadeAlphaA.color = new Color(255, 255, 255, alphaA);

        Transform transformA = CharacterA.GetComponent<Transform>();
        Vector2 pos = transformA.position;
        pos.y -= moveSpeed * Time.deltaTime;
        transformA.position = pos;


        if (alphaA <= 0)
        {
            isFadeout = false;
            alphaA = 0.0f;
            isFadein = true;
            isChange = true;
        }
    }

    void FadeInA()
    {
        alphaA += fadeOutSpeed * Time.deltaTime;
        fadeAlphaA.color = new Color(255, 255, 255, alphaA);

        Transform transformA = CharacterA.GetComponent<Transform>();
        Vector2 pos = transformA.position;
        pos.y += moveSpeed * Time.deltaTime;
        transformA.position = pos;

        if (alphaA >= 1)
        {
            isFadein = false;
            alphaA = 1.0f;
            isChange = false;
        }
    }

    void FadeOutB()
    {
        isStop = true;
        alphaB -= fadeOutSpeed * Time.deltaTime;
        fadeAlphaB.color = new Color(255, 255, 255, alphaB);

        Transform transformB = CharacterB.GetComponent<Transform>();
        Vector2 pos = transformB.position;
        pos.y -= moveSpeed * Time.deltaTime;
        transformB.position = pos;

        if (alphaB <= 0)
        {
            isFadeout = false;
            alphaB = 0.0f;
            isFadein = true;
            isChange = true;
        }
    }

    void FadeInB()
    {
        alphaB += fadeOutSpeed * Time.deltaTime;
        fadeAlphaB.color = new Color(255, 255, 255, alphaB);

        Transform transformB = CharacterB.GetComponent<Transform>();
        Vector2 pos = transformB.position;
        pos.y += moveSpeed * Time.deltaTime;
        transformB.position = pos;

        if (alphaB >= 1)
        {
            isFadein = false;
            alphaB = 1.0f;
            isChange = false;
        }
    }
}
