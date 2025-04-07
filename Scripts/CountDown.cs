using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private int countdownStartValue = 3; // The starting value of the countdown
    private GameObject One;
    private GameObject Two;
    private GameObject Three;
    private GameObject senceSetActive;
    ScenceSetActive sence;

    public GameObject rewardedUnlock;
    public GameObject continueCountDown;

    private AudioSource rewardSound;

    static public bool isRewarded = false;
    void Start()
    {
        rewardSound = GetComponent<AudioSource>();
        senceSetActive = GameObject.Find("SenceSetActive");
        sence = senceSetActive.GetComponent<ScenceSetActive>();

        One = GameObject.Find("One");
        Two = GameObject.Find("Two");
        Three = GameObject.Find("Three");

        One.SetActive(false);
        Two.SetActive(false);
        Three.SetActive(false);

        if (isRewarded)
        {
            this.PlaySound();
            this.rewardedUnlock.SetActive(true);
            this.continueCountDown.SetActive(true);
            isRewarded = false;
        }
        else 
        {
            this.CountDownFunction();
        }

    }

    public void CountDownFunction()
    {
        this.rewardedUnlock.SetActive(false);
        this.continueCountDown.SetActive(false);
        this.StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {

        while (this.countdownStartValue > 0)
        {
            Debug.Log("Countdown: " + this.countdownStartValue);
            if (this.countdownStartValue == 3)
            {
                Three.SetActive(true);
                One.SetActive(false);
                Two.SetActive(false);
            }
            else if (this.countdownStartValue == 2)
            {
                Three.SetActive(false);
                One.SetActive(false);
                Two.SetActive(true);
            }
            else if(this.countdownStartValue == 1)
            {
                Three.SetActive(false);
                One.SetActive(true);
                Two.SetActive(false);
            }

            yield return new WaitForSeconds(1f);

            this.countdownStartValue -= 1;
        }


        this.sence.LoadSenceByName("MainPlay");
        this.sence.UnloadSceneByName("CountDown");
    }

    void PlaySound()
    {
        rewardSound.Play();
    }
}
