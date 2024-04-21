using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour
{   
    public static ExitButtonController instance;
    public bool startStaging = false;

    public void ButtonExit()
    {
        startStaging = true;
    }
}