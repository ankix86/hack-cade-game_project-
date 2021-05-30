﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float movementSpeed = 10;
  public float jumpForce = 200;
  private Rigidbody2D rb;
  bool isFacingRight = true;
  Quaternion rotation;
  public Transform checkGround;
  public LayerMask whatIsGround,whatIsLadder;
  bool isGrounded;
  public GameObject collideObject;
  public float checkRadius;
  private bool isClimbing = false;
  public int extraJumpsValue = 0;
  private int extraJumps;

  public float distance = 10.0f;
  float startTime;

  void Start()
  {
    startTime = Time.time;
    extraJumps = extraJumpsValue;
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  void Update()
  {
      isGrounded = Physics2D.OverlapCircle(checkGround.position, checkRadius, whatIsGround);
      movement();
      jump();
      Climb();
  }

  void movement()
  {
      float h = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(h * movementSpeed , rb.velocity.y);
      //Facing
      if (h > 0 && !isFacingRight)
      {
          isFacingRight = true;
          rotation.y = 0;
          transform.rotation = rotation;
      }
      else if (h < 0 && isFacingRight)
      {
          isFacingRight = false;
          rotation.y = 180;
          transform.rotation = rotation;
      }
  }

  void jump()
  {

      if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
      {
          rb.velocity = Vector2.up * jumpForce;
          extraJumps--;
      }
      else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
      {
          rb.velocity = Vector2.up * jumpForce;
      }
      if (isGrounded)
      {
          extraJumps = extraJumpsValue;
      }
  }

  void Climb()
  {
      RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
      Debug.DrawLine(transform.position,transform.position + transform.up * distance);
      if (hitInfo)
      {
          if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
          {
              isClimbing = true;
          }
      }
      else
      {
          if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
          {
              isClimbing = false;
          }
      }
      if (isClimbing && hitInfo.collider != null)
      {
          rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * movementSpeed /1.5f);
          rb.gravityScale = 0;
      }
      else
      {
          rb.gravityScale = 2;
      }
  }
}
