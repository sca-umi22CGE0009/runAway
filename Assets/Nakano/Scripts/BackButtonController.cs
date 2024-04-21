using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    [SerializeField] private GameObject ConfirmationWindow;

    public void OnClick()
    {
        ConfirmationWindow.SetActive(false);
    }
}
