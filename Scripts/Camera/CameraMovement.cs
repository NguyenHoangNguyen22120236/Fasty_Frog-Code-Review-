using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CemeraMovement : MonoBehaviour
{
    private GameObject frog;
    private Vector3 speed;
    private Vector3 posCurrent;

    private float less;
    private float more;
    private float middle;

    private float moveFirst;
    private float moveLast;
    private float moveMiddlePlus;
    private float moveMiddleMinus;

    private float addMoreSpeed = 0.0f; //0.14
    private float addMiddleSpeed = 0.1f;

    private bool checkReturn = false;

    static public float randomForFrog_First;
    static public float randomForFrog_Last;

    void Start()
    {
        this.frog = GameObject.Find("Frog");

        randomForFrog_First = 0.5f;
        randomForFrog_Last = 1.8f;

        this.moveFirst = transform.position.x - frog.transform.position.x ;
        this.moveLast = frog.transform.position.x - transform.position.x ;
        this.moveMiddlePlus = (transform.position.x - frog.transform.position.x) / 2;
        this.moveMiddleMinus = (frog.transform.position.x - transform.position.x) / 2;

        posCurrent = transform.position;
    }

    void Update()
    {
        if(this.checkReturn == true)
        {
            this.posCurrent.x += this.speed.x;
            transform.position = this.posCurrent;

            return;
        }

        this.CheckMode();


        if (this.frog.transform.position.x - transform.position.x <= this.moveLast) //9
        {
            this.speed.x = this.less;
            randomForFrog_First = 1f;
            randomForFrog_Last = 1.8f;
            this.checkReturn = true;
            StartCoroutine(WaitCheckReturn(0.2f));
        }    
        else if (this.frog.transform.position.x - transform.position.x >= this.moveFirst) //9
        {
            this.speed.x = this.more;
            randomForFrog_First = 0.5f;
            randomForFrog_Last = 1f;
            this.checkReturn = true;
            StartCoroutine(WaitCheckReturn(0.2f));
        }
        else if (this.frog.transform.position.x - transform.position.x >= this.moveMiddleMinus || this.frog.transform.position.x - transform.position.x <= this.moveMiddlePlus)
        {
            this.speed.x = this.middle;
            randomForFrog_First = 0.5f;
            randomForFrog_Last = 1.8f;
        }    

        this.posCurrent.x += this.speed.x;
        transform.position = this.posCurrent;

    }

    IEnumerator WaitCheckReturn(float second)
    {
        yield return new WaitForSecondsRealtime(second);

        this.checkReturn = false;
    }

    void CheckMode()
    {
        if (ModePlay.mode == "Very Easy")
        {
            this.less = 0.04f + this.addMoreSpeed - this.addMoreSpeed; //0.004
            this.more = 0.6f + this.addMoreSpeed; //+ this.addMoreSpeed; //0.18
            this.middle = 0.2f + this.addMiddleSpeed; //0.075
        }
        else if (ModePlay.mode == "Easy")
        {
            this.less = 0.045f + this.addMoreSpeed - this.addMoreSpeed;
            this.more = 0.65f + this.addMoreSpeed; //+ this.addMoreSpeed;
            this.middle = 0.25f + this.addMiddleSpeed;
        }
        else if (ModePlay.mode == "Normal")
        {
            this.less = 0.055f + this.addMoreSpeed - this.addMoreSpeed; //0.008
            this.more = 0.9f + this.addMoreSpeed; //+ this.addMoreSpeed; //0.28
            this.middle = 0.3f + this.addMiddleSpeed; //0.081
        }
        else if (ModePlay.mode == "Hard")
        {
            this.less = 0.065f + this.addMoreSpeed - this.addMoreSpeed; //0.01
            this.more = 1.2f + this.addMoreSpeed; //+ this.addMoreSpeed; //0.32
            this.middle = 0.4f + this.addMiddleSpeed; //0.085
        }
        else if (ModePlay.mode == "Harder")
        {
            this.less = 0.075f + this.addMoreSpeed - this.addMoreSpeed; //0.012
            this.more = 1.4f + this.addMoreSpeed; //+ this.addMoreSpeed; //0.35
            this.middle = 0.5f + this.addMiddleSpeed; //0.088
        }
        else if (ModePlay.mode == "Very Hard")
        {
            this.less = 0.085f + this.addMoreSpeed - this.addMoreSpeed; //0.0165
            this.more = 1.7f + this.addMoreSpeed; //+ this.addMoreSpeed; //0.38
            this.middle = 0.7f + this.addMiddleSpeed; //0.093
        }
    }
}
