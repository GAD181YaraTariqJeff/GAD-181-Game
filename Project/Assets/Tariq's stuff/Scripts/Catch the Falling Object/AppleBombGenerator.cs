using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBombGenerator : MonoBehaviour
{

    float timer = 1f;
    public GameObject[] gm;
     

    void Start()
    {
        
    }


    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int chance = Random.Range(1, 101);
            float pos_x = Random.Range(-6.5f, 6.5f);

            if(chance <= 35)
            {
                Instantiate(gm[1], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0,0));
            }
            else
            {
                Instantiate(gm[0], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }

            timer = 0.7f;
        }




    }
}
