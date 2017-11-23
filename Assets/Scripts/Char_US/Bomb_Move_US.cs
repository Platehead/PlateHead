﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Move_US : MonoBehaviour {
    
    public ParticleSystem Eff;
    public float time;
    public float Speed;

	void Start ()
    {
        StartCoroutine(Move());
	}

    IEnumerator Move()
    {
        var TargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TargetPos.z = transform.position.z;
        TargetPos -= transform.position;
        TargetPos = transform.position + TargetPos.normalized * 300;

        float AngleRad = Mathf.Atan2(TargetPos.y - transform.position.y, TargetPos.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        
        float check = 0;

        while (check < time * 100)
        {
            transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, Speed);
            check += 1;
            yield return new WaitForSeconds(0.01f);
        }

        var eff = Instantiate(Eff);

        eff.transform.position = transform.position;
        eff.Play();
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}