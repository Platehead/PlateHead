using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LinearMoving : MonoBehaviour {
	public Transform targetTrans;
	public float moveTime;

	void Start() {
		transform.DOMove(targetTrans.position, moveTime);
		transform.DOMove(targetTrans.position, moveTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
	}
}
