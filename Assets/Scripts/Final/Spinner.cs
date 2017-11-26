using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	public float spawnDelay;
	public float refillDelay;
	public GameObject cb;
	
	void Start() {
		Invoke("Refill", spawnDelay);
	}

	void Update () {
		transform.Rotate(Time.deltaTime * Vector3.up * 180);
	}

	void Refill() {
		cb.SetActive(true);
	}

	public void Use() {
		Invoke("Refill", refillDelay);
	}
}
