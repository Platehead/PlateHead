using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    bool IsJump = false;

    void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Jump());
    }

    private void FixedUpdate()
    {
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.A))
                transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            else if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }

    IEnumerator Jump()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.W) && !IsJump)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
                IsJump = true;
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
            IsJump = false;
    }

    private void OnBecameInvisible()
    {
        GameObject obj = Instantiate(gameObject);
        Destroy(gameObject);
        obj.transform.position = new Vector3(0, 0, 0);
    }
}
