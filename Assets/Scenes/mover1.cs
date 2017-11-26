using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover1 : MonoBehaviour
{

    // Use this for initialization

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
        }
    }
}

