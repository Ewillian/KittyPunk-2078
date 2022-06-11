using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public Variables

    public float movementSpeed;
    public float jumpForce;

    public bool isGround;
    public bool isJump;

    public Rigidbody2D rb;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    #endregion

    #region Private Variables
        
    private Vector3 velocity = Vector3.zero;

    #endregion

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJump = true;
        }
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJump = false;
        }
    }
}
