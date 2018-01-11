using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof (CircleCollider2D))] 
public class PlayerController : DestructableEnitity {

    CircleCollider2D myColl;
    Rigidbody2D myrb2d;
    public float moveSpeed = 10.0f;

    protected override void Start()
    {
        base.Start();
        myColl = GetComponent<CircleCollider2D>();
        myrb2d = GetComponent<Rigidbody2D>();
    }

    void Update () {
        Vector2 moveDir = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveVelocity = moveDir * moveSpeed;

        myrb2d.velocity = (moveVelocity * Time.fixedDeltaTime);
	}
}
