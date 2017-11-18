using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_AutoDestroy : MonoBehaviour {

    ParticleSystem ps;

	void Start ()
    {
        ps = GetComponent<ParticleSystem>();
	}
	
	void Update ()
    {
		if (ps && !ps.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
