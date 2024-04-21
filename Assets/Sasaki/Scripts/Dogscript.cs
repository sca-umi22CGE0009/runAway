using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogscript : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    [SerializeField]
    private GameObject text;
    private Animator anim = null;
    //[SerializeField]
    private GameObject charaA;
    [SerializeField]
    private GameObject dog;

    GameObject child;

    private bool isDog;
    public static bool dogAttack;
    int n;

    void Start()
    {
        isDog = false;
        dogAttack = false;
        anim = GetComponent<Animator>();
        //ÉqÉGÉâÉãÉLÅ[Ç©ÇÁíTÇ∑
        charaA = GameObject.FindWithTag("Player");

        child = transform.Find("DogAttack").gameObject;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //å¢Ç…êGÇ¡ÇΩÇÁ
        if (isDog)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                child.SetActive(true);
                anim.SetBool("run", true);
                text.SetActive(false);
                dogAttack = true;
                n++;
            }
        }
        if (n >= 1)
        {
            text.SetActive(false);
        }
    }
    //êGÇÍÇƒÇ¢ÇΩÇÁ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);

            isDog = true;
        }
    }
    //êGÇÍÇƒÇ¢Ç»Ç©Ç¡ÇΩÇÁ
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            isDog = false;
        }

        if (charaA.transform.position.x > dog.transform.position.x)
        {
            Destroy(this.gameObject, 7f);
        }
    }
    //éwíËÉLÅ[ÇâüÇµÇΩÇÁ
    public bool TriggerCheck()
    {
        if (dogAttack)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
