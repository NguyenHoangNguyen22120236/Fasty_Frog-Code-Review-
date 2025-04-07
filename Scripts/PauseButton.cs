using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private GameObject pasueButton;
    private GameObject continueButton;

    private void Start()
    {
        pasueButton = GameObject.Find("PauseButton");
        continueButton = GameObject.Find("ContinueButton");
    }

    public void PauseGame()
    {
        pasueButton.SetActive(false);
        continueButton.SetActive(true);

        Time.timeScale = 0f;
    }
}
