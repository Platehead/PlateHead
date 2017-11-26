using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	public GameObject owner;
	public int damage;
	public float lifeSpan;
	public float speed;
	public GameObject effectPrefab;

	void Start () {
		StartCoroutine(BulletCoroutine());
	}
	
	IEnumerator BulletCoroutine() {
		var timer = 0f;

		while(timer < lifeSpan) {
			transform.Translate(Vector3.right * transform.localScale.x * speed * Time.deltaTime);
			timer += Time.deltaTime;
			yield return null;
		}

		Destroy(gameObject);
		yield break;
	}

	void OnTriggerEnter(Collider coll) {
		Debug.Log(coll.gameObject.name);
		if (coll.gameObject == owner)
			return;
		var characterBase = coll.GetComponent<CharacterBase>();
		if (characterBase != null) {
			characterBase.GetDamage(damage);
		}
		var contactPos = coll.ClosestPointOnBounds(transform.position);
		Instantiate(effectPrefab, contactPos + Vector3.back * 15, Quaternion.identity);
		Destroy(gameObject);
	}
}
