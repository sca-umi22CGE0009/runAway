using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //25�b�o�߂������̓G���^�[�L�[����������
        if (time >= 25.0f || (Input.GetKey(KeyCode.Return) && time >= 1.0f))
        {
            //�^�C�g���V�[���ɑJ�ڂ���
            SceneManager.LoadScene("TitleScene");
        }
    }
}
