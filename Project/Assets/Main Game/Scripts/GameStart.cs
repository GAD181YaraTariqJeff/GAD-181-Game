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
            showInstruction.ShowInstructionText("Use A or D to move and SPACE to jump, touch the arcade machines for a suprise and to revert press P");
        }
    }
}
