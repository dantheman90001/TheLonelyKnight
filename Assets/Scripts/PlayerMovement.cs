using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public Joystick jb;
    public float jumpSpeed = 10f;
    public CharacterController2D controller;
    bool Jumping = false;
    float horizontalMove;
    float x;
    bool Crouching = false;
    [Range(1, 10)]
    public float jumpVelocity;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = x = jb.Horizontal * speed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        float verticalMove = jb.Vertical * jumpSpeed;
        if (verticalMove >= 7f)
        {
            Jumping = true;
            animator.SetBool("IsJumping", true);
        }
        if (verticalMove > -1f)
        {
            Crouching = false;
        }
        else if (verticalMove < -4.5f)
        {
            Crouching = true;
        }
        if (verticalMove >= 0f)
        {
            Crouching = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void Attack()
    {
        Debug.Log("Attacking");
        animator.SetBool("Attack", true);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, Crouching, Jumping);
        Jumping = false;
    }
}
