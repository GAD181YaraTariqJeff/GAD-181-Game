using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public ShowTutorial showInstruction;
    private void Start()
    {
        if (showInstruction != null)
        {
            showInstruction.ShowInstructionText("Use A or D to move and SPACE to jump, go near the arcade machines for a suprise and press E. Also if something bad happens just press P");
        }
    }
}
