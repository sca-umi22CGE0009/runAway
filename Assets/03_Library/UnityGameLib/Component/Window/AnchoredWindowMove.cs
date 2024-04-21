using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class AnchoredWindowMove : MonoBehaviour,IUpdateManager
{
    [SerializeField,Header("�ړ���������component")]
    RectTransform rectTransform;

    [SerializeField,Header("�ړI�̍��W")]
    Vector2 target;

    [SerializeField,Header("�ړ��̑���")]
    float speed;

    Vector2 vec2;

    private void OnDisable()
    {
        rectTransform.anchoredPosition = vec2;
    }

    void Start() 
    {
        vec2 = rectTransform.anchoredPosition;
     
        UpdateManager.Instance.Bind(this,FrameControl.ON);  
    }

    public void OnUpdate(double deltaTime)
    {
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition,target,speed * Time.deltaTime);
    }
}
    