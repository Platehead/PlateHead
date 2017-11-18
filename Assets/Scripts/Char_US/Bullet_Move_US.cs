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
        var MousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        int Flip = (MousePos.x < Screen.width / 2) ? -1 : 1;

        while (true)
        {
            transform.position += new Vector3(Speed * Flip, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
