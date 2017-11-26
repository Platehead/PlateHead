using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Kimchi : MonoBehaviour {
	void OnEnable() {
		transform.localRotation = Quaternion.identity;
		transform.DOLocalRotate(new Vector3(0, 0, -180), 0.25f).SetEase(Ease.Linear)
			.OnComplete(()=>transform.DOLocalRotate(new Vector3(0, 0 , -359), 0.25f).SetEase(Ease.Linear));
	}
}
