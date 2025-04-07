using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModePlayManager : MonoBehaviour
{
    public int countEasy;
    public int countNormal;
    public int countHard;
    public int countHarder;
    public int countVeryHard;

    public List<int> listNumber = new List<int>();

    public bool watchAds = false;

    void Start()
    {
        this.intializeMode();
    }

    public void updateMode()
    {
        if (this.watchAds == true)
        {
            Debug.Log("Mode: " + ModePlay.mode);
            if (ModePlay.mode == "Very Easy")
            {
                int easyMode = 0;

                if (this.countEasy - ModePlay.count <= 4)
                {
                    easyMode = 4;
                }
                else
                {
                    easyMode = this.countEasy - ModePlay.count;
                }

                this.setMode(easyMode, easyMode + 15, easyMode + 15 + 35, easyMode + 15 + 35 + 30, easyMode + 15 + 35 + 30 + 25);
            }
            else if (ModePlay.mode == "Easy")
            {
                int normalMode = 0;
                if (this.countNormal - ModePlay.count <= 4)
                {
                    normalMode = 8;
                }
                else
                {
                    normalMode = this.countNormal - ModePlay.count + 4;
                }

                this.setMode(4, normalMode, normalMode + 35, normalMode + 35 + 30, normalMode + 35 + 30 + 25);
            }
            else if (ModePlay.mode == "Normal")
            {
                int hardMode = 0;

                if (this.countHard - ModePlay.count <= 4)
                {
                    hardMode = 12;
                }
                else
                {
                    hardMode = this.countHard - ModePlay.count + 8;
                }

                this.setMode(4, 8, hardMode, hardMode + 30, hardMode + 30 + 25);
            }
            else if (ModePlay.mode == "Hard")
            {
                int harderMode = 0;

                if (this.countHarder - ModePlay.count <= 4)
                {
                    harderMode = 16;
                }
                else
                {
                    harderMode = this.countHarder - ModePlay.count + 12;
                }

                this.setMode(4, 8, 12, harderMode, harderMode + 25);
            }
            else if (ModePlay.mode == "Harder")
            {
                int veryHardMode = 0;
                if (this.countVeryHard - ModePlay.count <= 4)
                {
                    veryHardMode = 20;
                }
                else
                {
                    veryHardMode = this.countVeryHard - ModePlay.count + 16;
                }

                this.setMode(4, 8, 12, 16, veryHardMode);
            }
            else if (ModePlay.mode == "Very Hard")
            {
                int veryHardMode = 0;

                if (this.countVeryHard - ModePlay.count <= 4)
                {
                    veryHardMode = 20;
                }
                else
                {
                    veryHardMode = this.countVeryHard - ModePlay.count + 16;
                }

                this.setMode(4, 8, 12, 16, veryHardMode);
            }
        }
        else
        {
            this.intializeMode() ;
        }
    }

    public void intializeMode()
    {
        this.countEasy = 15;
        this.countNormal = 30;
        this.countHard = 65;
        this.countHarder = 95;
        this.countVeryHard = 120;
    }

    public void setMode (int easy, int normal, int hard, int harder, int veryHard)
    {
        this.countEasy = easy;
        this.countNormal = normal;
        this.countHard = hard;
        this.countHarder = harder;
        this.countVeryHard = veryHard;
    }

    public void UpdateListNumber(List<int> listNumber)
    {
        this.listNumber = listNumber;
    }

    public void ClearListNumber()
    {
        this.listNumber.Clear();
    }

    public List<int> GetListNumber()
    {
        return this.listNumber;
    }

    public void printMode()
    {
        Debug.Log("Easy " + countEasy);
        Debug.Log("Normal " + countNormal);
        Debug.Log("Hard " + countHard);
        Debug.Log("Harder " + countHarder);
        Debug.Log("Very Hard " + countVeryHard);

    }
}
