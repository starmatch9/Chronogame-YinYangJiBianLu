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

    //检测是否在平台上
    bool onPlatform;

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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.Normalize();
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = false;
        }
    }
}
