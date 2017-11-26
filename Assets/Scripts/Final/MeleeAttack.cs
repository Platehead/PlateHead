using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAttackable {
	public GameObject attackObj;
	public int damage;
	public float preDelay;
	public float duration;
	bool isAttacking;

	public void Attack() {
		if (isAttacking)
			return;
		StartCoroutine(AttackCoroutine());
	}

	IEnumerator AttackCoroutine() {
		isAttacking = true;
		yield return new WaitForSeconds(preDelay);
		attackObj.SetActive(true);
		yield return new WaitForSeconds(duration);
		attackObj.SetActive(false);
		isAttacking = false;
		yield break;
	}
}
