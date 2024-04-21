using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TensionGuageController : MonoBehaviour
{
    [SerializeField] private Image tensionGuage;
    private float playerTension = 100;
    [SerializeField] private float Speed;

    [SerializeField] MainCharacter_State mainsCharacter_stateA;
    [SerializeField] MainCharacter_State mainsCharacter_stateB;

    //[SerializeField]
    //GameObject character;

    //[SerializeField]
    //Image chara_AttackImage;

    [SerializeField]
    BoxCollider2D boxCollider2d;

    bool isSkill;

    void Start()
    {
        boxCollider2d.enabled = false;
        //chara_AttackImage.enabled = false;
        isSkill = true;
    }

    void Update()
    {
        tensionGuage.fillAmount = playerTension / 100.0f;
        if(isSkill)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                playerTension -= 30;

                StartCoroutine(Attack());
            }
        }
        if(playerTension <= 100)
        {
            playerTension += Speed / 60.0f;
        }
        if(playerTension <= 0)
        {
            playerTension = 0;
        }

        if(playerTension < 30)
        {
            mainsCharacter_stateA.skillNg();
            mainsCharacter_stateB.skillNg();
            isSkill = false;
        }
        if(playerTension >= 30)
        {
            mainsCharacter_stateA.skillOk();
            mainsCharacter_stateB.skillOk();
            isSkill = true;
        }
    }

    IEnumerator Attack()
    {
        //character.SetActive(false);
        //chara_AttackImage.enabled = true;
        boxCollider2d.enabled = true;
        
        yield return new WaitForSeconds(0.3f);

        boxCollider2d.enabled = false;
        //chara_AttackImage.enabled = false;
        //character.SetActive(true);
    }
}
