using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecideButtonController : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}
