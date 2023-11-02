using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpClick : MonoBehaviour
{
    public PlayerController playerController; 
    public float maxJumpDuration = 3f; // 最大ジャンプ時間
    public float jumpForcePerLevel = 3f; // ジャンプ力増加量
    public float jumpInterval = 1f; // ジャンプ力を増加させる間隔

    private float jumpDuration; // ジャンプボタンを押している時間
    private float jumpForceLevel = 1; // ジャンプ力
    private bool isJumping; 
    private float nextJumpIncreaseTime; 


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }


    public void OnClickDown()
    {
        isJumping = true;
        jumpDuration = 0f; //ジャンプを押してる時間をリセット
        jumpForceLevel = 1; //ジャンプレベルをリセット
        nextJumpIncreaseTime = Time.time + jumpInterval; //時間が0だとジャンプしないため、0.5秒追加する。
    }


    public void OnClickUP()
    {
        isJumping = false;
        float jumpForce = jumpForcePerLevel * jumpForceLevel; 
        playerController.Jump(jumpForce); // プレイヤーのスクリプトにジャンプ力を設定する
    }

    private void Update()
    {
        if (isJumping)
        {
            jumpDuration += Time.deltaTime;
            jumpDuration = Mathf.Clamp(jumpDuration, 0f, maxJumpDuration); // 最大ジャンプ持続時間を制限

            if (Time.time >= nextJumpIncreaseTime && jumpForceLevel < 5) 
            {
                nextJumpIncreaseTime += jumpInterval; 
                jumpForceLevel++; //ジャンプ力の増加

                Debug.Log("JumpForce: ");
            }
        }
    }
}