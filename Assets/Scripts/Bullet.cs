using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    public float speed;

    void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke("SelfDestroy", lifeTime);
    }
    // Update is called once per frame
    void Update () {
        transform.position += speed * Vector3.right * Time.deltaTime;		
	}
}