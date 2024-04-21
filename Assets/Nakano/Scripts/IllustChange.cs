using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IllustChange : MonoBehaviour
{
    private Image m_Image;
    public Sprite[] m_Sprite;
    int textNumber;
    private bool isChange;

    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        textNumber = OpeningTextManager.textNumber;
        isChange = FadeManager.isChange;

        if (isChange)
        {
            switch (textNumber)
            {
                case 0:
                case 1:
                    m_Image.sprite = m_Sprite[0];
                    break;
                case 2:
                    m_Image.sprite = m_Sprite[1];
                    break;
                case 3:
                    m_Image.sprite = m_Sprite[4];
                    break;
                case 4:
                case 5:
                case 6:
                    m_Image.sprite = m_Sprite[2];
                    break;
                case 7:
                    m_Image.sprite = m_Sprite[0];
                    break;
                case 8:
                case 9:
                    m_Image.sprite = m_Sprite[3];
                    break;
                }
            }
    }
}
