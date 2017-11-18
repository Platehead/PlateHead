using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move_US : MonoBehaviour {

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

        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, Speed);
            yield return null;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
