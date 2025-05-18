using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    //行走速度
    public float speed = 10.0f;
    //跳跃初速度
    public float jumpHigh = 3.0f;

    Rigidbody2D body;
    Vector2 movement = new Vector2();

    //获取角色渲染器
    public SpriteRenderer spriteRenderer;

    //检测是否在平台上
    bool onPlatform;

    //动画器
    public Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveBody();
        if (onPlatform && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    //左右移动
    private void MoveBody()
    {
        body.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.Normalize();
        //反转
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        // 根据是否有水平输入来控制跑步动画
        bool hasHorizontalInput = Mathf.Abs(movement.x) > 0.1f; // 阈值避免浮点数误差
        animator.SetBool("isRun", hasHorizontalInput);

        if (!hasHorizontalInput)
        {
            body.constraints |= RigidbodyConstraints2D.FreezePositionX;

        }
        body.velocity = new Vector2(movement.x * speed, body.velocity.y);

    }
    //跳
    private void Jump()
    {
        //v^2 = 2gh
        float jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * body.gravityScale * jumpHigh);
        body.velocity = new Vector2(body.velocity.x, jumpVelocity);
    }

    //碰撞检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform") || collision.gameObject.layer == LayerMask.NameToLayer("YinDoor") || collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            onPlatform = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform") || collision.gameObject.layer == LayerMask.NameToLayer("YinDoor") || collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            onPlatform = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform") || collision.gameObject.layer == LayerMask.NameToLayer("YinDoor") || collision.gameObject.layer == LayerMask.NameToLayer("YangDoor"))
        {
            onPlatform = false;
        }
    }
}
