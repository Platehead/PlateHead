using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCon_Test : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpSpeed = 5f;
    public float Gravity = 20f;

    CharacterController con;
    Vector3 Move_Dir;

    private void Start()
    {
        con = GetComponent<CharacterController>();
        Move_Dir = Vector3.zero;
    }

    void Update ()
    {
        if (con.isGrounded)
        {
            Move_Dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Move_Dir = transform.TransformDirection(Move_Dir);
            Move_Dir *= Speed;

            if (Input.GetKeyDown(KeyCode.W))
                Move_Dir.y = JumpSpeed;
        }

        Move_Dir.y -= Gravity * Time.deltaTime;
        con.Move(Move_Dir * Time.deltaTime);
    }
}
