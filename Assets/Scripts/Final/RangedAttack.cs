using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour, IAttackable {
	public GameObject bulletPrefab;
	public Transform gunPoint;
	public int numberOfBullets;
	public float shotInterval;
	public float preDelay;
	bool isAttacking;
	public float postDelay;
	public void Attack() {
		if (isAttacking)
			return;
		
		StartCoroutine(AttackCoroutine());
	}
	IEnumerator AttackCoroutine() {
		isAttacking = true;
		yield return new WaitForSeconds(preDelay);
		var numberToFire = numberOfBullets;
		float sign = Mathf.Sign(gunPoint.position.x - transform.position.x);
		while (numberToFire > 0) {
			Debug.Log(numberToFire);
			numberToFire --;
			var bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
			bullet.GetComponent<BulletBehavior>().owner = gameObject;
			bullet.transform.localScale = new Vector3(sign, 1, 1);
			yield return new WaitForSeconds(shotInterval);
		}
		yield return new WaitForSeconds(postDelay);
		isAttacking = false;
		yield break;
	}
}
