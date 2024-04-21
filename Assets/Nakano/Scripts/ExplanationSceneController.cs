using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplanationSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Explanation;
    [SerializeField] private GameObject ExplanationText;
    [SerializeField] private GameObject ItemsExplanation;
    [SerializeField] private GameObject ItemsExplanationText;

    int enter = 0;

    void Start()
    {
        Explanation.SetActive(true);
        ExplanationText.SetActive(true);
        ItemsExplanation.SetActive(false);
        ItemsExplanationText.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            enter += 1;
        }

        switch(enter)
        {
            case 1:
                ItemsExplanation.SetActive(true);
                ItemsExplanationText.SetActive(true);
            break;
            case 2:
                SceneManager.LoadScene("MainGame");
            break;
        }
    }
}
