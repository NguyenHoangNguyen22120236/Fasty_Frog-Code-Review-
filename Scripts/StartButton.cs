using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private GameObject senceSetActive;
    ScenceSetActive sence;

    private void Start()
    {
        senceSetActive = GameObject.Find("SenceSetActive");
        sence = senceSetActive.GetComponent<ScenceSetActive>();
    }

    public void StartGame()
    {
        sence.LoadSenceByName("Instruction");
        sence.UnloadSceneByName("Menu");
    }
}
