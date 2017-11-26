using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpBarManager : MonoBehaviour {
	public Transform hpBar;
	public Transform tempHpBar;
	public CharacterBase targetCharacter;
	float lengthMultiplier;
	int currentHealth;

	public GameObject titleButton;
	public GameObject bgmObject;
	public GameObject winFXObject;
	public Text winText;
	public int index;

	public void Initialize() {
		lengthMultiplier = 1f / targetCharacter.maxHP;
		targetCharacter.HpChangeAction = OnHpChanged;
	}

	void OnHpChanged(int newHp) {
		hpBar.DOScaleX(lengthMultiplier * newHp, 0.2f)
			.OnComplete(
			() => {
			tempHpBar.DOKill();
			tempHpBar.DOScaleX(lengthMultiplier * newHp, 3f);
		});
		Debug.Log(lengthMultiplier * newHp);

		if (newHp == 0)
			EndGame();
	}

	void Start() {
		Initialize();
	}

	void EndGame() {
		if (winFXObject.activeInHierarchy)
			return;
		
		bgmObject.SetActive(false);
		winFXObject.SetActive(true);

		winText.gameObject.SetActive(true);
		winText.rectTransform.localPosition = new Vector3((index - 1.5f) * 4000, 100, 0);
		winText.text = "플레이어 " + index.ToString() + " 승리!";
		winText.transform.DOLocalMoveX(0, 1f)
			.SetEase(Ease.InOutElastic)
			.OnComplete(
				() => titleButton.SetActive(true));
	}

	public void BackToTitle() {
		Application.LoadLevel(0);
	}
}
