using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGruondImage : MonoBehaviour
{
    static int count = 1;

    bool flag = true;
    public int Count => count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            flag = false;
            count++;
        }
    }
}
