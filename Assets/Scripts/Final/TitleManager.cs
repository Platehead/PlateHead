using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleManager : MonoBehaviour {
	public Transform target;

	public void StartGame() {
		target.DOLocalMoveX(-2000, 0.5f)
			.OnComplete(() => Application.LoadLevel(1));
	}
}
