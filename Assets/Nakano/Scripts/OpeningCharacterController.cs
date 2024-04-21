using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCharacterController : MonoBehaviour
{
    //��l��A
    [SerializeField] private GameObject BackGroundA; //�w�i
    [SerializeField] private GameObject ANormal; //�ʏ�
    [SerializeField] private GameObject ASurprise; //����
    [SerializeField] private GameObject AWorry; //�Y��
    [SerializeField] private GameObject ASmile; //�������Ί�
    [SerializeField] private GameObject APanic; //�ł�
    [SerializeField] private GameObject SerifA; //�Z���t

    Image fadeAlphaA1, fadeAlphaA2, fadeAlphaA3, fadeAlphaA4, fadeAlphaA5;
    float alphaA1, alphaA2, alphaA3, alphaA4, alphaA5;

    //��l��B
    [SerializeField] private GameObject BackGroundB; //�w�i
    [SerializeField] private GameObject BNormal; //�ʏ�
    [SerializeField] private GameObject BSurprise; //����
    [SerializeField] private GameObject BWorry; //�Y��
    [SerializeField] private GameObject BSmile; //�������Ί�
    [SerializeField] private GameObject BPanic; //�ł�
    [SerializeField] private GameObject SerifB; //�Z���t

    Image fadeAlphaB1, fadeAlphaB2, fadeAlphaB3, fadeAlphaB4, fadeAlphaB5;
    float alphaB1, alphaB2, alphaB3, alphaB4, alphaB5;

    Image fadeAlpha;
    float alpha;
    bool fadeout;
    bool fadein;
    [SerializeField] private int fadeoutSpeed;
    [SerializeField] private int fadeinSpeed;
    [SerializeField] private float WaitTime;
    int number = 1;

    int selectCharacter = SelectSceneManager.selectCharacter;
    int textNumber = OpeningTextManager.textNumber;

    void First() //�����ݒ�
    {
        //��l��A
        BackGroundA.SetActive(false);
        ANormal.SetActive(false);
        SerifA.SetActive(false);

        fadeAlphaA1 = ANormal.GetComponent<Image>();
        alphaA1 = fadeAlphaA1.color.a;
        fadeAlphaA1.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);

        fadeAlphaA2 = ASurprise.GetComponent<Image>();
        alphaA2 = fadeAlphaA2.color.a;
        fadeAlphaA2.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaA3 = AWorry.GetComponent<Image>();
        alphaA3 = fadeAlphaA3.color.a;
        fadeAlphaA3.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaA4 = ASmile.GetComponent<Image>();
        alphaA4 = fadeAlphaA4.color.a;
        fadeAlphaA4.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaA5 = APanic.GetComponent<Image>();
        alphaA5 = fadeAlphaA5.color.a;
        fadeAlphaA5.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        //��l��B
        BackGroundB.SetActive(false);
        BNormal.SetActive(false);
        SerifB.SetActive(false);

        fadeAlphaB1 = BNormal.GetComponent<Image>();
        alphaB1 = fadeAlphaB1.color.a;
        fadeAlphaB1.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);

        fadeAlphaB2 = BSurprise.GetComponent<Image>();
        alphaB2 = fadeAlphaB2.color.a;
        fadeAlphaB2.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaB3 = BWorry.GetComponent<Image>();
        alphaB3 = fadeAlphaB3.color.a;
        fadeAlphaB3.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaB4 = BSmile.GetComponent<Image>();
        alphaB4 = fadeAlphaB4.color.a;
        fadeAlphaB4.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);

        fadeAlphaB5 = BPanic.GetComponent<Image>();
        alphaB5 = fadeAlphaB5.color.a;
        fadeAlphaB5.color = new Color(255.0f, 255.0f, 255.0f, 0.0f);
    }

    void SelectA()
    {
        BackGroundA.SetActive(true);
        ANormal.SetActive(true);
        ASurprise.SetActive(true);
        AWorry.SetActive(true);
        ASmile.SetActive(true);
        APanic.SetActive(true);

        //StartCoroutine("AillustManager");

        switch (number)
        {
            case 0:
                ANormal.SetActive(true);
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA1, alphaA1);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA2, alphaA2);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA2, alphaA2);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA5, alphaA5);
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA5, alphaA5);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA3, alphaA3);
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA3, alphaA3);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA1, alphaA1);
                }
                break;
            case 7:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA1, alphaA1);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA4, alphaA4);
                }
                break;
        }

        SerifA.SetActive(true);
    }

    void SelectB()
    {
        BackGroundB.SetActive(true);
        BNormal.SetActive(true);
        SerifB.SetActive(true);
    }

    void Start()
    {
        number = 1;
        selectCharacter = SelectSceneManager.selectCharacter;
        First();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            number += 1;
        }

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

    void FadeOut(Image fadeAlpha, float alpha)
    {
        alpha -= fadeoutSpeed * Time.deltaTime;
        fadeAlpha.color = new Color(255, 255, 255, alpha);
        if (alpha <= 0)
        {
            fadeout = false;
            alpha = 0.0f;
        }
    }

    void FadeIn(Image fadeAlpha, float alpha)
    {
        alpha += fadeinSpeed * Time.deltaTime;
        fadeAlpha.color = new Color(255, 255, 255, alpha);
        if (alpha >= 255)
        {
            fadein = false;
            alpha = 255.0f;
        }
    }

    /*IEnumerator AillustManager()
    {
        switch (number)
        {
            case 0:
                ANormal.SetActive(true);
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA1, alphaA1);
                    yield return new WaitForSeconds(WaitTime);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA2, alphaA2);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA2, alphaA2);
                    yield return new WaitForSeconds(WaitTime);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA5, alphaA5);
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA5, alphaA5);
                    yield return new WaitForSeconds(WaitTime);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA3, alphaA3);
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA3, alphaA3);
                    yield return new WaitForSeconds(WaitTime);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA1, alphaA1);
                }
                break;
            case 7:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    fadeout = true;
                }
                if (fadeout)
                {
                    FadeOut(fadeAlphaA1, alphaA1);
                    yield return new WaitForSeconds(WaitTime);
                }
                if (fadein)
                {
                    FadeIn(fadeAlphaA4, alphaA4);
                }
                break;
        }
    }*/
}
