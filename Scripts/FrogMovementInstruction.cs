using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovementInstruction : MonoBehaviour
{
    public Vector3 posCurrentFirst;
    private float jumpHeight = 4f; // Chiều cao nhảy tối đa
    private float jumpDuration; // Thời gian thực hiện một cú nhảy
    private Vector3 endPoint; // Điểm kết thúc
    private float timeElapsed = 0f;

    public MonoBehaviour[] scriptsToPause;
    public Animator animator;

    public GameObject woodGrey;
    public GameObject handCLick;
    public GameObject OKStartPlayButton;

    float window = 0.1f;

    float android = 0.04f;
    private void Start()
    {
        this.animator = GetComponent<Animator>();

        this.woodGrey = GameObject.Find("Wood_Grey");
        this.woodGrey.SetActive(false);

        this.handCLick = GameObject.Find("HandCLick");
        this.handCLick.SetActive(false);

        this.OKStartPlayButton = GameObject.Find("OKStartPlayButton");

        this.animator.Play("Frog_Jump_Instruction");

        this.jumpDuration = 1.3f; //1.3
        this.jumpHeight = this.OKStartPlayButton.transform.position.y - transform.position.y - 1f;

        this.posCurrentFirst = this.transform.position;

        this.endPoint = new Vector3(this.woodGrey.transform.position.x, this.transform.position.y, -38f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.timeElapsed < this.jumpDuration)
        {
            this.JumpParabol();

            if (this.jumpDuration - this.timeElapsed <= 0.2f && this.jumpDuration - this.timeElapsed >= 0f)
            {
                this.handCLick.SetActive(true);
            }

            if (this.jumpDuration - this.timeElapsed <= 0.1f && this.jumpDuration - this.timeElapsed >= 0f)
            {
                this.woodGrey.SetActive(true);
            }

        }
        else
        {
            this.animator.Play("Idle");
            StartCoroutine(PauseCoroutine(2f));
        }
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
        float xPos = Mathf.Lerp(this.posCurrentFirst.x, this.endPoint.x, t);

        // Tính toán vị trí y dựa trên parabol
        float yPos = Mathf.Lerp(this.posCurrentFirst.y, this.endPoint.y, t) + this.jumpHeight * Mathf.Sin(Mathf.PI * t);

        // Cập nhật vị trí của frog
        transform.position = new Vector3(xPos, yPos, -38f);
    }

    private IEnumerator PauseCoroutine(float pauseDuration)
    {
        this.scriptsToPause[0].enabled = false;
        // Wait for the specified duration in real-time seconds
        yield return new WaitForSecondsRealtime(pauseDuration);
        this.scriptsToPause[0].enabled = true;

        this.handCLick.SetActive(false);
        this.woodGrey.SetActive(false);
        this.animator.Play("Frog_Jump_Instruction");

        transform.position = this.posCurrentFirst;
        this.timeElapsed = 0f;
    }
}
