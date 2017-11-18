using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Move_US : MonoBehaviour {
    
    public ParticleSystem Eff;
    public float Speed;

	void Start ()
    {
        StartCoroutine(Move());
	}

    IEnumerator Move()
    {
        var MousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        int Flip = (MousePos.x < Screen.width / 2) ? -1 : 1;
        float check = 0;

        while (check < 100)
        {
            transform.position += new Vector3(Speed * Flip, 0, 0);
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
