using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; //移動速度

    public Transform groundCheck; //地面判定用のオブジェクト
    public LayerMask groundLayer; //地面のレイヤー
    private bool isGrounded; 
    private Rigidbody2D rb;

    private Animator animator;
    public FloatingJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//スタート時にRigidbodyを取得、Updateで計算適用に必要
        animator = GetComponent<Animator>(); // Animatorコンポーネントを取得
    }

    // Update is called once per frame
    void Update()
    {
        float x = joystick.Horizontal;

        // 水平方向の速度を設定　
        transform.position += new Vector3(x * moveSpeed, 0, 0);

        //地面に接しているかの判定
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // ジャンプアニメーションの制御
        animator.SetBool("Jump", !isGrounded); // IsJumpingパラメータを設定

        // プレイヤーのスプライトを取得
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // プレイヤーの向きを進行方向に合わせる
        if (x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }

    public void Jump(float jumpForce)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ジャンプ力
            isGrounded = false; 

            // ジャンプアニメーションのトリガーを発動
            animator.SetTrigger("Jump");

        }
    }
}