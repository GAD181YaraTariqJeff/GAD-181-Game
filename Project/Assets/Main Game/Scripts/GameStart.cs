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
            showInstruction.ShowInstructionText("Press Arrow Keys LEFT & RIGHT to 'Move'. Press SPACE to 'Jump' (Long Press to jump higher). Press E to 'Interact' with the arcade machines. Press P to 'Exit' the arcade machines. Press S to save a checkpoint (unlimited)");
        }
    }
}
