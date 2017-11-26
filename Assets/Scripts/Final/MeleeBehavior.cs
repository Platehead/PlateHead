using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour {

	public GameObject owner;
	public int damage;
	public GameObject effectPrefab;
	public List<GameObject> filterList;

	void OnEnable() {
		filterList = new List<GameObject>();
		filterList.Add(owner);
	}

	void OnTriggerEnter(Collider coll) {
		if (filterList.Contains(coll.gameObject))
			return;
		
		filterList.Add(coll.gameObject);
		var characterBase = coll.GetComponent<CharacterBase>();
		if (characterBase != null) {
			characterBase.GetDamage(damage);
			var contactPos = coll.ClosestPointOnBounds(transform.position);
			Instantiate(effectPrefab, contactPos + Vector3.back * 15, Quaternion.identity);
		}
	}
}
