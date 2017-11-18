using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {
	public Transform[] selectorTransforms;
	public GameObject[] selectorObjects;

	class Selector {
		public bool didSelect;
		public GameObject selectorObject;
		public int characterIndex;
		public List<Vector3> selectorPositions;
		
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
			Debug.Log("Selected");
		}
	}

	List<Selector> selectors;

	void Start() {
		var selectorPositions = selectorTransforms.Select((x) => x.position).ToList<Vector3>();
		var cnt = 0;
		selectors = selectorObjects.Select(
			(x) => {
				var selector = new Selector();
				selector.didSelect = false;
				selector.selectorObject = x;
				selector.selectorPositions = selectorPositions;
				selector.characterIndex = cnt;
				if (cnt == 0) {
					selector.leftKey = KeyCode.A;
					selector.rightKey = KeyCode.D;
					selector.selectKey = KeyCode.F;
				}
				else if (cnt == 1) {
					selector.leftKey = KeyCode.LeftArrow;
					selector.rightKey = KeyCode.RightArrow;
					selector.selectKey = KeyCode.Period;
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
				selector.Select();
				StartGame();
			}
		}
	}

	void StartGame() {
		foreach (var selector in selectors) {
			if (!selector.didSelect)
				return;
		}


	}
}
