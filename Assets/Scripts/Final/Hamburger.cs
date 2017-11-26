using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hamburger : BulletBehavior {
	public float distance;
	float rotationSpeed = 0.1f;
	void Start() {
		var sign = transform.localScale.x;
		transform.DOMoveX(transform.position.x + distance * sign, 
			lifeSpan * 0.5f)
			.SetEase(Ease.OutQuad)
			.OnComplete(
				() => {
					StartCoroutine(Rewind());
				});
	}
	void Update() {
		transform.Rotate(Vector3.forward * 360 * Time.deltaTime * rotationSpeed);
		rotationSpeed += Time.deltaTime;
	}

	IEnumerator Rewind() {
		var sign = transform.localScale.x;
		yield return new WaitForSeconds(1f);
		transform.DOMoveX(transform.position.x - distance * sign, 
			lifeSpan * 0.5f)
			.SetEase(Ease.InQuad)
			.OnComplete(
				() => {
					Destroy(gameObject);
				});
		yield break;
	}
}
