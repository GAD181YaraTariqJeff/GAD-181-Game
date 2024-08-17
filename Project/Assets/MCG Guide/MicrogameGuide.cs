using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// This script will be responsible of showing the guide for the microgames
/// </summary>
public class MicrogameGuide : MonoBehaviour
{
    public TextMeshProUGUI guideText; // Reference to the guide text UI element
    public float displayTime = 3f; // Time in seconds to display the guide before starting the game

    void Start()
    {
        StartCoroutine(DisplayGuideAndStartGame());
    }

    IEnumerator DisplayGuideAndStartGame()
    {
        // Ensure the guide text is enabled at the start
        guideText.gameObject.SetActive(true);

        // Wait for the specified display time
        yield return new WaitForSeconds(displayTime);

        // Hide the guide text
        guideText.gameObject.SetActive(false);

        // Start the microgame (replace this with your microgame start logic)
        StartMicrogame();
    }

    void StartMicrogame()
    {
        // Your microgame logic here
        Debug.Log("Microgame Started!");
    }
}
