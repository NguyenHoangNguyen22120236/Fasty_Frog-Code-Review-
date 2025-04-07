using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKStartPlayButton : MonoBehaviour
{
    private GameObject instruction;
    private GameObject okStartGameButton;
    private GameObject senceSetActive;
    private ScenceSetActive sence;

    private void Start()
    {
        this.senceSetActive = GameObject.Find("SenceSetActive");
        this.sence = this.senceSetActive.GetComponent<ScenceSetActive>();
    }
    public void StartGame()
    {
        this.sence.LoadSenceByName("CountDown");
        this.sence.UnloadSceneByName("Instruction");
    }
}
