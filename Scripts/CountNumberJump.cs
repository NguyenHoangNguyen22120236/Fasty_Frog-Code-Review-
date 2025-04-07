using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CountNumberJump : PrintNumberController
{
    protected bool WaitForListnumber;
    public GameObject constCountNumber;

    ModePlayManager modePlayManager;

    private void Start()
    {
        this.modePlayManager = GameObject.Find("ModePlayManager").GetComponent<ModePlayManager>();
        this.constCountNumber = GameObject.Find("ConstCountNumber");

        this.minusForSeperate = 30;
        this.posX = 0f;
        this.posY = this.constCountNumber.transform.position.y;
        this.posZ = 0f;

        if (this.modePlayManager.watchAds == false)
        {
            this.seperate.Add(40);
            this.UpdatePosUnit(0);

            this.listNumber.Add(0);

            this.listNewNumberPrefab.Add(NullGameObject);
            this.PrintNumberCharacter(0, 0);
        }
        else
        {
            // Logic continue count number jump
            this.listNumber = this.modePlayManager.GetListNumber();
            for (int i = 0; i < this.listNumber.Count; i++)
            {
                if (i == 0)
                {
                    this.seperate.Add(40);
                }
                else
                {
                    this.seperate.Add(this.seperate[i - 1] - this.minusForSeperate);
                }
                this.UpdatePosUnit(i);
                Debug.Log("listNumber[i]: " + this.listNumber[i]);
                this.listNewNumberPrefab.Add(NullGameObject);
                this.PrintNumberCharacter(this.listNumber[i], i);
            }
        }

        this.WaitForListnumber = false;
    }

    public void CheckWaitForListnumber(bool status)
    {
        this.WaitForListnumber = status;
    }

    private void Update()
    {
        if (this.WaitForListnumber == true)
        {
            this.WaitForListnumber = false;
            for (int i = 0; i < this.listNumber.Count; i++)
            {
                this.CheckAddListNumber(i);
            }
        }
    }

    public int GetScore()
    {
        int score = 0;

        for (int i = this.listNumber.Count - 1; i >= 0; i--)
        {
            score = score * 10 + this.listNumber[i];
        }

        return score;
    }

}

