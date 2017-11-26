using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour {
	public Transform p1Spawn;
	public Transform p2Spawn;
	public CharacterBase[] characters;
	public Sprite[] flags;
	public Image p1Flag;
	public Image p2Flag;
	public Image fader;

	public GameObject managerHolder;
	public HpBarManager manager1;
	public HpBarManager manager2;

	void Awake() {
		HpBarManager[] managerList = managerHolder.GetComponents<HpBarManager>();
		manager1 = managerList[0];
		manager2 = managerList[1];

		StartCoroutine(FadeIn());
		Spawn(PlayerSelection.p1Select, PlayerSelection.p2Select);
	}
	public void Spawn(int p1Index, int p2Index) {
		var p1Character = characters[p1Index];
		p1Character.gameObject.SetActive(true);
		p1Character.transform.position = p1Spawn.transform.position;
		p1Character.playerIndex = 1;
		p1Flag.sprite = flags[p1Index];
		manager1.targetCharacter = p1Character;

		var p2Character = characters[p2Index];
		p2Character.gameObject.SetActive(true);
		p2Character.transform.position = p2Spawn.transform.position;
		p2Character.playerIndex = 2;
		p2Flag.sprite = flags[p2Index];
		manager2.targetCharacter = p2Character;
	}

	IEnumerator FadeIn() {
		var timer = 1f;
		while (timer > 0) {
			fader.color = new Color(0, 0, 0, timer);
			timer -= Time.deltaTime;
			yield return null;
		}
		fader.gameObject.SetActive(false);
		yield break;
	}
}
