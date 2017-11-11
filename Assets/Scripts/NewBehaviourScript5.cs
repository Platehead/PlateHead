using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript5 : MonoBehaviour {
    private float speed = 10.0f;

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            jump();
        }
	}

    void jump()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
