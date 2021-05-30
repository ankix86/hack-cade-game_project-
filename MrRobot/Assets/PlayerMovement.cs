using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement_speed = 5f;
    public Animator animator;

    private Rigidbody2D rb;

    Vector2 movement;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y =  Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("speed",movement.sqrMagnitude);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
    }
}
