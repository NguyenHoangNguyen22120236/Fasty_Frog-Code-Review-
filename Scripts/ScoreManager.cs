using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using Unity.VisualScripting;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;


public class ScoreManager : PrintNumberController
{
    public CountNumberJump countNumberJump;

    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject bronzeMedal;
    public GameObject noMedal;

    public GameObject newScore;

    public List<Animator> listAnimator;

    protected int scoreReach;
    protected int scoreCurrent;

    protected Vector3 posUnitHighScore;
    protected float posHighScoreX;
    protected float posHighScoreY;
    protected float posHighScoreZ;

    protected List<float> seperateHighScore = new List<float>();

    private float timeElapsed = 0;
    private float timeEnd = 0.5f; //0.8

    private bool giveMedal = true;

    public GameObject tableScore;
    public GameObject constBestNumber;
    public GameObject constScoreNumber;

    private GameObject cameraMovement;

    private Vector3 posCurrent;

    private void Start()
    {
        this.constScoreNumber = GameObject.Find("ConstScoreNumber");
        this.constBestNumber = GameObject.Find("ConstBestNumber");
        this.cameraMovement = GameObject.Find("Main Camera");

        this.posCurrent = transform.position;

        this.posCurrent.x = cameraMovement.transform.position.x + this.posCurrent.x; 

        transform.position = this.posCurrent;

        this.posX = this.transform.position.x; //+ 50f;
        this.posY = this.constScoreNumber.transform.position.y;
        this.posZ = 3f;

        this.minusForSeperate = this.seperate2.transform.position.x - this.seperate1.transform.position.x;

        Debug.Log("minus Seperate " + minusForSeperate);

        this.posHighScoreX = this.transform.position.x;
        this.posHighScoreY = this.constBestNumber.transform.position.y;
        this.posHighScoreZ = 3f;

        this.seperateHighScore.Add(0);

        this.seperate.Add(0);
        UpdatePosUnit(0);
        listNumber.Add(0);

        listNewNumberPrefab.Add(NullGameObject);
        PrintNumberCharacter(0, 0);

        this.scoreReach = this.countNumberJump.GetScore();
        this.scoreCurrent = 0;

        Debug.Log("SCore reach: " + scoreReach);

        this.UpdateHighScore();
        this.PrintHighScore();
    }

    bool CheckForRunningPrintingScore()
    {
        if (this.timeElapsed > this.timeEnd)
        {
            return true;
        }
        this.timeElapsed += Time.fixedDeltaTime;
        return false;
    }

    private void Update()
    {
        if (this.CheckForRunningPrintingScore() == true)
        {
            if (this.scoreCurrent < this.scoreReach)
            {
                this.scoreCurrent += 1;
                AddToFirstElementListNumber(1);
                for (int i = 0; i < listNumber.Count; i++)
                {
                    CheckAddListNumber(i);
                    Thread.Sleep(15);
                }
            }
            else
            {
                if (this.giveMedal == true)
                {
                    this.giveMedal = false;
                    this.GiveMedal();
                }
                
            }
        }
    }

    void UpdateHighScore()
    {
        if (this.countNumberJump.GetScore() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", this.countNumberJump.GetScore());
            this.newScore.SetActive(true);
        }
    }

    void PrintHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        int temp = 0;
        int index = 0;


        if (highScore == 0)
        {
            this.seperateHighScore.Add(this.seperateHighScore[index] - this.minusForSeperate);
            this.UpdatePosUnitHighScore(index);
            this.InstantiateNumberInHighScore(highScore);

            return;
        }

        while (highScore > 0)
        {
            this.seperateHighScore.Add(this.seperateHighScore[index] - this.minusForSeperate);
            this.UpdatePosUnitHighScore(index);
            temp = highScore % 10;
            highScore = highScore / 10;

            this.InstantiateNumberInHighScore(temp);
            index += 1;
        }
    }

    void UpdatePosUnitHighScore(int index)
    {
        this.posUnitHighScore.x = this.posHighScoreX + this.seperateHighScore[index];
        this.posUnitHighScore.y = this.posHighScoreY;
        this.posUnitHighScore.z = this.posHighScoreZ;
    }

    void InstantiateNumberInHighScore(int number)
    {
        this.listNumberPrefab[number].SetActive(true);

        GameObject numberHighScore = Instantiate(this.listNumberPrefab[number], this.posUnitHighScore, Quaternion.identity);
        numberHighScore.transform.parent = transform;

        numberHighScore.transform.localScale = new Vector3(12.32227f, 12.32227f, 12.32227f);

        this.listNumberPrefab[number].SetActive(false);
    }

    void GiveMedal()
    {
        if (this.countNumberJump.GetScore() >= 0 && this.countNumberJump.GetScore() <= 15)
        {
            this.noMedal.SetActive(true);
        }
        else if (this.countNumberJump.GetScore() > 15 && this.countNumberJump.GetScore() <= 30)
        {
            this.bronzeMedal.SetActive(true);
            PrintShining();

        }
        else if (this.countNumberJump.GetScore() > 30 && this.countNumberJump.GetScore() <= 50)
        {
            this.silverMedal.SetActive(true);
            PrintShining();
        }
        else
        {
            this.goldMedal.SetActive(true);
            PrintShining();
        }
    }

    void PrintShining()
    {
        StartCoroutine(WaitForShining(1f));
    }    

    IEnumerator WaitForShining(float second)
    {
        while (true)
        {
            foreach (Animator animator in this.listAnimator)
            {
                animator.Play("Shining");

                yield return new WaitForSecondsRealtime(second);
               
                animator.Play("Idle");
            }
        }
    }
}
