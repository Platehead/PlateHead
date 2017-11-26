using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour {
	public float lifeSpan;
	void Start () {
		StartCoroutine(DestroySelf());
	}
	
	IEnumerator DestroySelf() {
		yield return new WaitForSeconds(lifeSpan);
		Destroy(gameObject);
	}
}
