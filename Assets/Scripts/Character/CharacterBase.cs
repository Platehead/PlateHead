using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {
	IAttackable attack1;
	IAttackable attack2;
	HpManager hpManager;
	Animator animator;
	CharacterController controller;

	public float speed;
	public float jumpPower;
	public int playerIndex;
	string horizontalAxisName;
	string verticalAxisName;
	string meleeButtonName;
	string rangedButtonName;
	bool isBlocked = false;
	int idleHash;
	int walkHash;
	int meleeHash;
	int rangedHash;

	float delay;

	void Start() {
		horizontalAxisName = "Horizontal";
		if (playerIndex > 1) {
			horizontalAxisName += playerIndex;
		}
		
		meleeButtonName = "Fire";
		meleeButtonName += (3 * playerIndex - 2).ToString();

		rangedButtonName = "Fire";
		rangedButtonName += (3 * playerIndex - 1).ToString();

		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

		idleHash = Animator.StringToHash("Idle");
		walkHash = Animator.StringToHash("Walk");
		meleeHash = Animator.StringToHash("Melee");
		rangedHash = Animator.StringToHash("Ranged");
	}

	void Update() {
		if (delay > 0) {
			delay -= Time.deltaTime;
		}

		var horizontalInput = Input.GetAxis(horizontalAxisName);
		
		if (Mathf.Abs(horizontalInput) > 0 && delay <= 0) {
			var sign = Mathf.Sign(horizontalInput);
			transform.localScale = new Vector3(sign, 1, 1);
			controller.SimpleMove(Vector3.right * horizontalInput * speed);
			animator.ResetTrigger(walkHash);
			animator.SetTrigger(walkHash);
		}
		else if (Mathf.Abs(horizontalInput) == 0 && delay <= 0) {
			animator.ResetTrigger(idleHash);
			animator.SetTrigger(idleHash);
		}

		if (Input.GetButtonDown(meleeButtonName) && delay <= 0) {
			animator.ResetTrigger(meleeHash);
			animator.SetTrigger(meleeHash);
			delay = 0.5f;
		}

		if (Input.GetButtonDown(rangedButtonName) && delay <= 0) {
			animator.ResetTrigger(rangedHash);
			animator.SetTrigger(rangedHash);
			delay = 0.5f;
		}
	}
}
