using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelDash : MonoBehaviour{

    Rigidbody2D rb2D;

    public float moveSpeed;

    public float jumpForce;
    public int jumpNum;
    int remainingJumpNum;

    public float dashForce;
    public float dashTime;
    bool isDash;
    float resumeTime;
    float direction;
    int remainingDashNum;
    public int dashNum;
    
    public GameObject ghostObject;
    public int ghostNum = 5;
    float ghostTime;

    public LayerMask ground;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 3;
    }

    private void Update() { 

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            direction = Input.GetAxisRaw("Horizontal");
        }
        if (rb2D.IsTouchingLayers(ground))
        {
            remainingDashNum = dashNum;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && remainingDashNum-- > 0)
        {
            isDash = true;
            resumeTime = Time.time + dashTime;
            rb2D.velocity = new Vector2(direction * dashForce, 0);
            rb2D.gravityScale = 0;
        }
        if (!isDash)
        {
            rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
            rb2D.angularVelocity = -rb2D.velocity.x / 0.5f * Mathf.Rad2Deg;
        }
        if(Time.time > resumeTime)
        {
            isDash = false;
            rb2D.gravityScale = 3;
        }
        if (rb2D.IsTouchingLayers(ground))
        {
            remainingJumpNum = jumpNum;
        }
        //一段跳使用力叠加
        if(Input.GetKeyDown(KeyCode.Space) && rb2D.IsTouchingLayers(ground))
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            remainingJumpNum--;
        }
        //多段跳使用坐标控制
        if(Input.GetKeyDown(KeyCode.Space) && !(rb2D.IsTouchingLayers(ground)) && remainingJumpNum-- > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
        if(isDash && Time.time > ghostTime)
        {
            Instantiate(ghostObject, transform.position, Quaternion.identity);
            ghostTime = Time.time + dashTime / ghostNum;
        }
    }
}
