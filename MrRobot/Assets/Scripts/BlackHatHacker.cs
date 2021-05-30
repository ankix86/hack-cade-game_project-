using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHatHacker : MonoBehaviour
{
   public Rigidbody2D rb;
	public float moveSpeed = 5f;
	public enum MoveDir { Left, Right }
	public MoveDir moveDir;
    public Animator animator;
    public GameObject rader;
    Quaternion rotation;
    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	void FixedUpdate()
	{
		if (moveDir == MoveDir.Left)
		{
			MoveLeft();
            rotation.y = 0;
            rader.gameObject.transform.rotation = rotation;
		}
		else if (moveDir == MoveDir.Right)
		{
			MoveRight();
            rotation.y = -180;
            rader.gameObject.transform.rotation = rotation;
		}
        animator.SetFloat("Horizontal",rb.velocity.x);
        animator.SetFloat("Vertical",rb.velocity.y);
        animator.SetFloat("Speed",rb.velocity.sqrMagnitude);
 
	}

	public float gapCheckDist;
	public Vector3 rightOffset;
	public Vector3 leftOffset;

	void MoveLeft()
	{
        //rotation.y = 0;
        //transform.rotation = rotation;

		var vec = new Vector3()
		{
			x = -moveSpeed,
			y = rb.velocity.y
		};

		rb.velocity = vec;
	}

	void MoveRight()
	{
		//rotation.y = 180;
       // transform.rotation = rotation;
		var vec = new Vector3()
		{
			x = moveSpeed,
			y = rb.velocity.y
		};

		rb.velocity = vec;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "wall")
		{
			if (collision.contacts[0].normal.x < 0 || collision.contacts[0].normal.x > 0)
			{
				if (moveDir == MoveDir.Left)
					moveDir = MoveDir.Right;
				else if (moveDir == MoveDir.Right)
					moveDir = MoveDir.Left;
			}
		}
	}

}
