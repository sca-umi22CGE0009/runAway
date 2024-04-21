using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    //Animator anim = null;
    bool isGameover;
    float alpha;
    float y;
    [SerializeField] float speed;
    [SerializeField] int wait = 5;
    
    void Start()
    {
        //anim = GetComponent<Animator>();
        isGameover = false;
        //anim.SetBool("gameover",false);
        //alpha = 0;
        this.GetComponent<Image>().color = new Color(255, 255, 255, 0);

        y = -540;
        this.GetComponent<Transform>().position = new Vector3(960, y, 0);
    }

    void Update()
    {
        if(isGameover)
        {
            //anim.SetBool("gameover", true);
            StartCoroutine("WaitTime");
        }

        //if(alpha >= 1)
        if(y >= 510)
        {
            StartCoroutine("Retry");
        }
    }

    public void GameOver()
    {
        isGameover = true;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
        //if (alpha <= 1)
        if(y <= 510)
        {
            //alpha += speed;
            //this.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            y += speed;
            this.GetComponent<Transform>().position = new Vector3 (960, y, 0);
        }
    }

    IEnumerator Retry()
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene("TitleScene");
    }
}
