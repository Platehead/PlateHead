using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwipeIn : MonoBehaviour {
	void Awake() {
		transform.localPosition = new Vector3(2000, 0, 0);
		transform.DOLocalMoveX(0, 0.5f);
	}
}
