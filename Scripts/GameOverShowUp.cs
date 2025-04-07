using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverShowUp: PrintNumberController
{
    private Vector3 posCurrent;
    private GameObject cameraMovement;
    private float posYToStop;
    private float posZBeShown = 0f;
    private float speed = 0.6f;
    private GameObject OKButton;

    static public bool GameOver;
    private GameObject pasueButton;
    private GameObject continueButton;

    public GameObject scoreManager;
    public GameObject countNumberJump;

    private bool printTableScore = true;

    public GameObject constGameOverStop;

    ModePlayManager modePlayManager;


    private void Start()
    {

        modePlayManager = GameObject.Find("ModePlayManager").GetComponent<ModePlayManager>();
        this.constGameOverStop = GameObject.Find("ConstGameOverStop");
        this.posYToStop = this.constGameOverStop.transform.position.y;  

        this.countNumberJump = GameObject.Find("CountNumberJump");
        this.cameraMovement = GameObject.Find("Main Camera");

        this.OKButton = GameObject.Find("OKPlayAgainButton");
        this.OKButton.SetActive(false);

        this.pasueButton = GameObject.Find("PauseButton");
        this.continueButton = GameObject.Find("ContinueButton");

        this.posCurrent = transform.position;
        this.posCurrent.y += 12;

        GameOver = false;
        this.UpdatePos();
    }

    private void Update()
    {
        if (GameOver == true)
        {
            Time.timeScale = 0f;

            this.TurnOffCountNumberJump();
            this.TurnOffPauseCOntinueButton();
            this.StartCoroutine(WaitSecondPrintGameOver(1f));

            if (this.printTableScore == true)
            {
                this.printTableScore = false;
                this.StartCoroutine(WaitSecondPrintTableScore(2.2f));
            }
        }
        else
        {
            this.UpdatePos();
        }
    }

    void UpdatePos()
    {
        this.posCurrent.x = this.cameraMovement.transform.position.x + 0.6f;  //for android
        transform.position = this.posCurrent;
    }

    void GameOverDown()
    {
        this.posCurrent.z = this.posZBeShown;
        if (transform.position.y > this.posYToStop)
        {
            this.posCurrent.y -= this.speed;
            transform.position = this.posCurrent;
        }
    }

    void OKButtonShow()
    {
        this.OKButton.SetActive(true);
    }

    void TurnOffCountNumberJump()
    {
        this.modePlayManager.UpdateListNumber(this.countNumberJump.GetComponent<CountNumberJump>().getListNumber());
        this.countNumberJump.SetActive(false);
    }

    void TurnOffPauseCOntinueButton()
    {
        this.pasueButton.SetActive(false);
        this.continueButton.SetActive(false);
    }

    IEnumerator WaitSecondPrintGameOver(float second)
    {
        yield return new WaitForSecondsRealtime(second);
        
        this.GameOverDown();
    }

    IEnumerator WaitSecondPrintTableScore(float second)
    {
        yield return new WaitForSecondsRealtime(second);

        this.OKButtonShow();
        this.scoreManager.SetActive(true);
    }
}
