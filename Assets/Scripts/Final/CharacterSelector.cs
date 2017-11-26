using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public Transform[] selectorTransforms;
	public GameObject[] selectorObjects;
	List<int> selects;
	public AudioSource selectSound;
	public Image fader;
	class Selector {
		public int playerIndex;
		public bool didSelect;
		public GameObject selectorObject;
		public int characterIndex;
		public List<Vector3> selectorPositions;
		public AudioSource selectSound;
		
		public KeyCode leftKey;
		public KeyCode rightKey;
		public KeyCode selectKey;

		public void Move(int direction) {
			if (didSelect)
				return;

			characterIndex += direction;

			if (characterIndex < 0)
				characterIndex += selectorPositions.Count;
			
			if (characterIndex >= selectorPositions.Count)
				characterIndex -= selectorPositions.Count;

			selectorObject.transform.position = selectorPositions[characterIndex];
		}
		
		public void Select() {
			if (didSelect)
				return;
			didSelect = true;
			selectSound.Play();
			Debug.Log("Selected");
		}
	}

	List<Selector> selectors;

	void Start() {
		selects = new List<int>();
		selects.Add(-1);
		selects.Add(-1);
		var selectorPositions = selectorTransforms.Select((x) => x.position).ToList<Vector3>();
		var cnt = 0;
		selectors = selectorObjects.Select(
			(x) => {
				var selector = new Selector();
				selector.selectSound = selectSound;
				selector.didSelect = false;
				selector.selectorObject = x;
				selector.selectorPositions = selectorPositions;
				selector.characterIndex = cnt;
				selector.playerIndex = cnt;
				if (cnt == 0) {
					selector.leftKey = KeyCode.A;
					selector.rightKey = KeyCode.D;
					selector.selectKey = KeyCode.F;
				}
				else if (cnt == 1) {
					selector.leftKey = KeyCode.LeftArrow;
					selector.rightKey = KeyCode.RightArrow;
					selector.selectKey = KeyCode.Slash;
				}
				cnt ++;
				return selector;
		}).ToList<Selector>();
	}

	void Update () {
		foreach (var selector in selectors) {
			if (Input.GetKeyDown(selector.leftKey)) {
				selector.Move(-1);
			}
			else if (Input.GetKeyDown(selector.rightKey)) {
				selector.Move(1);
			}
			else if (Input.GetKeyDown(selector.selectKey)) {
				if (!selects.Contains(selector.characterIndex)) {
					selector.Select();
					selects[selector.playerIndex] = selector.characterIndex;
					StartGame();
				}
			}
		}
	}

	void StartGame() {
		foreach (var selector in selectors) {
			if (!selector.didSelect)
				return;
		}
		PlayerSelection.p1Select = selectors[0].characterIndex;
		PlayerSelection.p2Select = selectors[1].characterIndex;
		
		StartCoroutine(FadeAndStart());
		
	}
	IEnumerator FadeAndStart() {
		var timer = 1f;
		while (timer > 0) {
			fader.color = new Color(0, 0, 0, 1 - timer);
			timer -= Time.deltaTime;
			yield return null;
		}
		Application.LoadLevel(2);
	}
}
