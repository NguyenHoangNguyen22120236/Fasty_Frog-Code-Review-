using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private GameObject senceSetActive;
    ScenceSetActive sence;
    ModePlayManager modePlayManager;

    void Start()
    {
        senceSetActive = GameObject.Find("SenceSetActive");
        sence = senceSetActive.GetComponent<ScenceSetActive>();
        this.modePlayManager = GameObject.Find("ModePlayManager").GetComponent<ModePlayManager>();
    }

    public void PlayAgain()
    {
        GameOverShowUp.GameOver = false;
        Time.timeScale = 1f;

        this.modePlayManager.ClearListNumber();
        this.modePlayManager.watchAds = false;
        modePlayManager.intializeMode();

        sence.LoadSenceByName("Menu");
        sence.UnloadSceneByName("MainPlay");
    }
}
