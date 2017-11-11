using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour {
    //총알의 파괴력
    public int damage = 20;
    //총알의 속도
    public float speed = 1000.0f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
