using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerControll : MonoBehaviour {
    public float inputThreshold;
	public float jumpPower;
	public float moveSpeed;
	float distToGround;
	Rigidbody2D rb;
	int layerMask;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		var collider2D = GetComponent<Collider2D>();
		distToGround = collider2D.bounds.extents.y;
		Debug.Log(distToGround);
		layerMask = 1 << LayerMask.NameToLayer("Ground");
	}
	void Update() {
		var horizontalInput = Input.GetAxis("Horizontal");
		if (Mathf.Abs(horizontalInput) > inputThreshold) {
			Move(horizontalInput);
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			Jump();
		}
	}

	void Jump() {
		if (IsJumpable()) {
			rb.AddForce(Vector2.up * jumpPower);
		}
		else
			return;
	}

	bool IsJumpable() {
		return Physics2D.Raycast(transform.position, 
			Vector2.down, distToGround + 0.1f, layerMask);
	}

	void Move(float input) {
		transform.position += Vector3.right * input * Time.deltaTime * moveSpeed;
	}
}
