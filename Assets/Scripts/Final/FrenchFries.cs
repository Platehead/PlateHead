using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FrenchFries : BulletBehavior {
	public float distance;
	void Start() {
		transform.DOMoveX(transform.position.x + transform.localScale.x * distance, lifeSpan)
			.OnComplete(() => {Destroy(gameObject);})
			.SetEase(Ease.InCubic);
	}
}
