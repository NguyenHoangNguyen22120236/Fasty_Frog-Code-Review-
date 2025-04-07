using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    private GameObject pasueButton;
    private GameObject continueButton;

    private void Start()
    {
        pasueButton = GameObject.Find("PauseButton");
        continueButton = GameObject.Find("ContinueButton");
    }

    public void ContinueGame()
    {
        continueButton.SetActive(false);
        pasueButton.SetActive(true);

        Time.timeScale = 1f;

    }
}
