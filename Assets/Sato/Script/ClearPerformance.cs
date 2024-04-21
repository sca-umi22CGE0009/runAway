using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearPerformance : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    [SerializeField]
    GameObject Car;

    [SerializeField]
    GameObject mainChara;

    bool isCarMove, isRide;

    Vector3 carScale, carScaleRe;

    void Start()
    {
        isCarMove = false;
        isRide = false;
        Car.SetActive(false);

        carScale = new Vector3(2, 2, 1);
        carScaleRe = new Vector3(-2, 2, 1);
        Car.transform.localScale = carScale;
    }

    void Update()
    {
        Transform carPos = Car.transform;
        Vector3 pos = carPos.position;

        if (isCarMove)
        {
            Car.SetActive(true); //�Ԃ�\��

            if (!isRide)
            {
                if (pos.x >= 0)
                {
                    pos.x -= 10 * Time.deltaTime;
                    carPos.position = pos;
                }
                else
                {
                    SpriteRenderer main = mainChara.GetComponent<SpriteRenderer>();
                    main.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    isRide = true;
                }
            }

            if (isRide) //��l�����Ԃɏ������
            {
                Car.transform.localScale = carScaleRe; //�摜���]

                if (pos.x <= 15)
                {
                    pos.x += 10 * Time.deltaTime;
                    carPos.position = pos;
                }
                else
                {
                    fade.FadeIn(1f);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
                }
            }
        }
    }

    public void CarMove()
    {
        isCarMove = true;
    }
}
