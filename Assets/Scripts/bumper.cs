using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour {
    public Rigidbody bullet;
    public float power = 1500f;
    public float movepower = 2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveDistanceX = movepower * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveDistanceY = movepower * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(moveDistanceX, moveDistanceY, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody instance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            instance.AddForce(fwd * power);
        }
	}
}
