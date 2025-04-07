using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModePlay : MonoBehaviour
{
    static public string mode;

    static public int count;

    ModePlayManager modePlayManager;

    private void Awake()
    {
        modePlayManager = GameObject.Find("ModePlayManager").GetComponent<ModePlayManager>();
        mode = "Very Easy";
        count = 0;
    }

    private void Update()
    {
        if (count == modePlayManager.countEasy)
        {
            mode = "Easy";
        }
        if (count == modePlayManager.countNormal)
        {
            mode = "Normal";
        }
        else if (count == modePlayManager.countHard)
        {
            mode = "Hard";
        }
        else if (count == modePlayManager.countHarder)
        {
            mode = "Harder";
        }    
        else if (count == modePlayManager.countVeryHard)
        {
            mode = "Very Hard";
        }
    }
}
