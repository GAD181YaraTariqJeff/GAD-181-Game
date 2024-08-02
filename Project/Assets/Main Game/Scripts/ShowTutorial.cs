using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    public TextMeshProUGUI instructionText;  // Reference to the TMP Text UI element
    public float displayDuration = 3f;  // Duration to display the text

    private void Start()
    {
        if (instructionText != null)
        {
            instructionText.gameObject.SetActive(true); 
        }
    }

    public void ShowInstructionText(string message)
    {
        if (instructionText != null)
        {
            instructionText.text = message;  // Set the text message
            StartCoroutine(ShowTextCoroutine());
        }
    }

    private IEnumerator ShowTextCoroutine()
    {
        instructionText.gameObject.SetActive(true);  // Show the text
        yield return new WaitForSeconds(displayDuration);  // Wait for the specified duration
        instructionText.gameObject.SetActive(false);  // Hide the text
    }
}
