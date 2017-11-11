using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTest : MonoBehaviour {

    HpManager botHp;

    void Start ()
    {
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dd");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("dd");
    }
}
