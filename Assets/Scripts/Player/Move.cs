using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    //�����ٶ�
    public float speed = 10.0f;
    //��Ծ���ٶ�
    public float jumpHigh = 3.0f;

    Rigidbody2D body;
    Vector2 movement = new Vector2();

    //��ȡ��ɫ��Ⱦ��
    public SpriteRenderer spriteRenderer;

    //����Ƿ���ƽ̨��
    bool onPlatform;

    //������
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

    //�����ƶ�
    private void MoveBody()
    {
        body.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.Normalize();
        //��ת
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        // �����Ƿ���ˮƽ�����������ܲ�����
        bool hasHorizontalInput = Mathf.Abs(movement.x) > 0.1f; // ��ֵ���⸡�������
        animator.SetBool("isRun", hasHorizontalInput);

        if (!hasHorizontalInput)
        {
            body.constraints |= RigidbodyConstraints2D.FreezePositionX;

        }
        body.velocity = new Vector2(movement.x * speed, body.velocity.y);

    }
    //��
    private void Jump()
    {
        //v^2 = 2gh
        float jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * body.gravityScale * jumpHigh);
        body.velocity = new Vector2(body.velocity.x, jumpVelocity);
    }

    //��ײ���
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
