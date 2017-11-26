using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixir : MonoBehaviour {

	public Spinner holder;
	void OnTriggerEnter(Collider coll) {
		var character = coll.GetComponent<CharacterBase>(); 
		if (character) {
			character.GetDamage(-30);
			holder.Use();
			gameObject.SetActive(false);
		}

	}
}
