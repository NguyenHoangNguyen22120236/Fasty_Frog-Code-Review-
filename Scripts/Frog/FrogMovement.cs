using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float ModeHardRand_X; //Điểm random đầu (Hard) 5
    public float ModeHardRandX_; //Điểm random cuối (Easy) 18

    public Vector2 posCurrent;
    private float jumpHeight; // Chiều cao nhảy tối đa
    private float jumpDuration; // Thời gian thực hiện một cú nhảy
    private Vector2 endPoint; // Điểm kết thúc
    private float endPointY;
    private float ExceedEndPointY;
    private float timeElapsed = 0f;

    private GameObject waterBlowUp;
    private Vector3 waterBlowUpPos = new Vector3(-10f, -4f, -10f);
    private AudioSource frogJumpSound;

    private GameObject CNJ;
    private CountNumberJump countNumberJump;

    public GameObject constJumpHeightFrog;

    public GameObject MainCamera;

    private float intialDistanceCamera_Frog;

    float window = 0.1f;
    float android = 0.04f;

    void Start()
    {
        this.MainCamera = GameObject.Find("Main Camera");
        this.intialDistanceCamera_Frog = this.MainCamera.transform.position.x - transform.position.x;

        //this.ModeHardRand_X = (this.intialDistanceCamera_Frog) / 2;
        //this.ModeHardRandX_ = (this.intialDistanceCamera_Frog) * 1.8f;

        this.UpdateModeHardRand();

        this.constJumpHeightFrog = GameObject.Find("ConstJumpHeightFrog");

        this.CNJ = GameObject.Find("CountNumberJump");
        this.countNumberJump = CNJ.GetComponent<CountNumberJump>();

        this.waterBlowUp = GameObject.Find("WaterBlowUp");
        this.waterBlowUp.SetActive(false);
        this.frogJumpSound = GetComponent<AudioSource>();

        this.jumpDuration = 0.8f; //4
        this.jumpHeight = this.constJumpHeightFrog.transform.position.y - transform.position.y;

        this.endPointY = transform.position.y;
        this.ExceedEndPointY = transform.position.y - 0.55f;

        this.posCurrent = transform.position;
        this.endPoint = RandomX();
    }

    private void Update()
    {
        this.CheckMode();

        // Tính toán vị trí mới của frog theo đường parabol
        if (this.timeElapsed < this.jumpDuration)
        {
            this.JumpParabol();
        }
        //Nếu khi hạ cánh ở trên lá thì tiếp tục
        else if (FrogCrontroller.isOnLeaf == true)
        //if (this.endPointY >= transform.position.y) //
        {
            PlaySound();
            this.timeElapsed = 0f;
            this.posCurrent = transform.position;
            this.endPoint = RandomX();
            ModePlay.count += 1;

            this.countNumberJump.AddToFirstElementListNumber(1);
            this.countNumberJump.CheckWaitForListnumber(true);
        }

        CheckGameOver();
    }

    void UpdateModeHardRand()
    {
        this.ModeHardRand_X = (this.intialDistanceCamera_Frog) * CemeraMovement.randomForFrog_First;
        this.ModeHardRandX_ = (this.intialDistanceCamera_Frog) * CemeraMovement.randomForFrog_Last;
    }

    Vector2 RandomX()
    {
        this.UpdateModeHardRand();

        float randomX = Random.Range(this.posCurrent.x + ModeHardRand_X, this.posCurrent.x + ModeHardRandX_);
       
        Vector2 endPoint_R = new Vector2(randomX, endPointY);

        return endPoint_R;
    }

    void JumpParabol()
    {
        this.timeElapsed += Time.deltaTime;
        float t = this.timeElapsed / this.jumpDuration;

        if (t > 1f)
        {
            t = 1f;
        }

        // Interpolate theo trục X
        float xPos = Mathf.Lerp(this.posCurrent.x, this.endPoint.x, t);

        // Tính toán vị trí y dựa trên parabol
        float yPos = Mathf.Lerp(this.posCurrent.y, this.endPoint.y, t) + this.jumpHeight * Mathf.Sin(Mathf.PI * t);

        // Cập nhật vị trí của frog
        transform.position = new Vector2(xPos, yPos);
    }

    void CheckMode()
    {
        if (ModePlay.mode == "Very Easy")
        {
            this.jumpDuration = 0.8f; //4.5
        }
        else if (ModePlay.mode == "Easy")
        {
            this.jumpDuration = 0.7f; //4.3
        }
        else if (ModePlay.mode == "Normal")
        {
            this.jumpDuration = 0.6f; //4.1
        }
        else if (ModePlay.mode == "Hard")
        {
            this.jumpDuration = 0.5f; //3.9
        }
        else if (ModePlay.mode == "Harder")
        {
            this.jumpDuration = 0.45f; //3.7
        }    
        else if (ModePlay.mode == "Very Hard")
        {
            this.jumpDuration = 0.35f; //3.5
        }
    }

    void CheckGameOver()
    {
        if (transform.position.y < this.ExceedEndPointY)
        {
            this.waterBlowUp.SetActive(true);
            this.waterBlowUpPos.x = transform.position.x;
            this.waterBlowUpPos.y = transform.position.y + 0.3f;
            this.waterBlowUpPos.z = 129;

            this.waterBlowUp.transform.position = this.waterBlowUpPos;

            GameOverShowUp.GameOver = true;
        }
    }

    void PlaySound()
    {
        frogJumpSound.Play();
    }
}
