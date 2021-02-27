using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ThirdPersonMovement : Pawn
{
    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    M4A1 m4;

    public int amountMagazines = 3;

    public Vector3 directon;

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        directon = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 moveDir = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(moveDir.normalized * speed * Time.deltaTime);
    }
}
