using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterBase : MonoBehaviour {
	IAttackable attack1;
	IAttackable attack2;
	Animator animator;
	CharacterController controller;
	
	bool isAlive = true;

	public Action<int> HpChangeAction;

	public int HP {
		get {
			return _hp;
		}
		set {
			_hp = value;
		}
	}
	public int _hp = 100;
	

	public int maxHP;

	public float inputThreshold;
	public float jumpPower;
	public float moveSpeed;
	float distToGround;
	int layerMask;
	public int playerIndex;

	public float attack1Delay;
	public float attack2Delay;

	float scale;
	string horizontalAxisName;
	string verticalAxisName;
	string meleeButtonName;
	string rangedButtonName;
	string jumpButtonName;
	bool isBlocked = false;
	int idleHash;
	int walkHash;
	int meleeHash;
	int rangedHash;


	float jumpForce;

	float delay;
	float delay1;
	float delay2;

	public Drink drink;

	void Start() {
		HP = maxHP;
		scale = transform.localScale.x;
		horizontalAxisName = "Horizontal";
		if (playerIndex > 1) {
			horizontalAxisName += playerIndex.ToString();
		}
		
		meleeButtonName = "Fire";
		meleeButtonName += (3 * playerIndex - 2).ToString();

		rangedButtonName = "Fire";
		rangedButtonName += (3 * playerIndex - 1).ToString();

		jumpButtonName = "Fire";
		jumpButtonName += (3 * playerIndex).ToString();

		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

		idleHash = Animator.StringToHash("Idle");
		walkHash = Animator.StringToHash("Walk");
		meleeHash = Animator.StringToHash("Melee");
		rangedHash = Animator.StringToHash("Ranged");

		layerMask = 1 << LayerMask.NameToLayer("Ground");
		distToGround = controller.bounds.extents.y;

		var attacks = GetComponents<IAttackable>();
		attack1 = attacks[0];
		attack2 = attacks[1];
	}

	void Update() {
		if (delay > 0) {
			delay -= Time.deltaTime;
		}
		if (delay1 > 0)
			delay1 -= Time.deltaTime;
		if (delay2 > 0)
			delay2 -= Time.deltaTime;

		var horizontalInput = Input.GetAxis(horizontalAxisName);
		Vector3 moveInput = Vector3.zero;
		
		if (isAlive) {
			if (Mathf.Abs(horizontalInput) > 0) {
				var sign = Mathf.Sign(horizontalInput);
				transform.localScale = new Vector3(sign * scale, scale, 1);
				moveInput = Vector3.right * horizontalInput * Time.deltaTime * moveSpeed;
				animator.SetBool(walkHash, true);
				if (drink)
					drink.hasMoved = true;	
			}
			
			if (!IsGrounded() || Mathf.Abs(horizontalInput) == 0) {
				animator.SetBool(walkHash, false);
			}

			if (Input.GetButtonDown(meleeButtonName) && delay <= 0 & delay1 <= 0) {
				animator.ResetTrigger(meleeHash);
				animator.SetTrigger(meleeHash);
				attack1.Attack();
				delay = 0.5f;
				delay1 = attack1Delay;
			}

			if (Input.GetButtonDown(rangedButtonName) && delay <= 0 && delay2 <= 0) {
				animator.ResetTrigger(rangedHash);
				animator.SetTrigger(rangedHash);
				attack2.Attack();
				delay = 0.5f;
				delay = attack2Delay;
			}

			if (Input.GetButtonDown(jumpButtonName) && delay <=0 && IsJumpable()) {
				jumpForce = jumpPower;
			}

			if (transform.position.y < -20)
				GetDamage(1000);
		}
		else {
			animator.SetTrigger(idleHash);
		}

		if (!IsGrounded())
			jumpForce -= 30 * Time.deltaTime;

		moveInput.y = Mathf.Clamp(jumpForce * Time.deltaTime, -0.3f, jumpPower);
		controller.Move(moveInput);
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, 
			Vector2.down, distToGround + 0.1f, layerMask);
	}

	bool IsJumpable() {
		return Physics.Raycast(transform.position, 
			Vector2.down, distToGround + 0.5f, layerMask);
	}

	public void GetDamage(int damage) {
		if (!isAlive)
			return;
		Debug.Log("Damage" + damage);
		HP = Mathf.Clamp(HP - damage, 0, maxHP);
		if (HpChangeAction != null)
			HpChangeAction(HP);
		
		if (HP == 0) {
			isAlive = false;
			transform.DORotate(Vector3.forward * 90, 0.5f);
			}
			
	}

	public void GetKnockBack(float power) {

	}
}
