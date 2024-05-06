using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{
    private Dogscript dog;

    bool boxCheck;

    void Start()
    {
        dog = GameObject.FindWithTag("Dog").GetComponent<Dogscript>();

        boxCheck = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCheck = true;
        }
    }
}
