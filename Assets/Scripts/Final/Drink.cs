using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drink : MonoBehaviour, IAttackable {
	public GameObject drinkObject;
	public Transform drinkGauge;
	public Transform drinkCan;
	public GameObject effect;
	public CharacterBase owner;
	public MeleeBehavior melee;

	public float timeConsumption;
	public float movableTime;
	public float effectDuration;

	public bool hasMoved;
	bool isAttaking;
	Vector3 canPosition;

	void Awake() {
		canPosition = drinkCan.localPosition;
	}
	public void Attack() {
		if (isAttaking)
			return;
		StartCoroutine(DrinkCoroutine());
	}

	IEnumerator DrinkCoroutine() {
		isAttaking = true;
		hasMoved = false;
		var timer = 0f;
		drinkObject.SetActive(true);
		drinkCan.localEulerAngles = Vector3.zero;
		drinkCan.localPosition = canPosition;
		drinkGauge.localScale = new Vector3(0, 1, 1);
		drinkCan.DORotate(Vector3.forward * 135 * owner.transform.localScale.x * 2, movableTime)
			.OnComplete(() => drinkCan.DOLocalMoveY(6, 0.5f)
				.SetLoops(-1, LoopType.Yoyo));

		while (timer < timeConsumption) {
			if (hasMoved) {
				if (timer < movableTime) {
					hasMoved = false;
					Debug.Log("Saved");
				}
				else {
					FinishDrinking();
					isAttaking = false;
					yield break;
				}
			}
			drinkGauge.localScale = new Vector3(timer / timeConsumption, 1, 1);
			timer += Time.deltaTime;
			yield return null;
		}
		FinishDrinking();
		ApplyEffect(true);
		yield return new WaitForSeconds(effectDuration);
		isAttaking = false;
		ApplyEffect(false);
		yield break;
	}

	void FinishDrinking() {
		drinkCan.DOKill();
		drinkObject.SetActive(false);
	}

	void ApplyEffect(bool isOn) {
		effect.SetActive(isOn);
		if (isOn) {
			owner.moveSpeed *= 2f;
			owner.jumpPower *= 1.5f;
			melee.damage *= 2;
			melee.transform.localScale = new Vector3(1, 2, 1);
		}
		else {
			owner.moveSpeed = 10;
			owner.jumpPower = 15;
			melee.damage = 10;
			melee.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
