using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelDoubleJump : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float moveSpeed;
    public float jumpForce;
    public LayerMask ground;
    public int jumpNum;
    int remainingJumpNum;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 3;
    }

    private void Update() {
        rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);

        if (rb2D.IsTouchingLayers(ground) && rb2D.velocity.y == 0)
        {
            remainingJumpNum = jumpNum;
        }

        if (Input.GetKeyDown(KeyCode.Space) && remainingJumpNum-- > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }
}
