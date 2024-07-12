using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSquares : MonoBehaviour
{
    public bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        
    }
    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    private void OnMouseEnter()
    {
        if(!isTriggered)
        {
            CleanIt.nOfSquaresToTrigger--;
            Debug.Log(CleanIt.nOfSquaresToTrigger);
        }
        isTriggered = true;
        
    }
}
