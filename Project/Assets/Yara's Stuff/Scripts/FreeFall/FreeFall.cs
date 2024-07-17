using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FreeFall : MonoBehaviour
{
    [SerializeField] TMP_Text EndGameMessage;
    public static bool hitACloud = false;
    // Start is called before the first frame update
    void Start()
    {
        EndGameMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(hitACloud)
        {
            GameObject[] AllCloudObjects = GameObject.FindGameObjectsWithTag("Cloud");
            foreach (GameObject o in AllCloudObjects)
            {
                Destroy(o);
            }
            GameObject player = GameObject.FindGameObjectWithTag("Player");
             Destroy(player);
        }
    }
}
