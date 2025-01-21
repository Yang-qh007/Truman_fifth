using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Y : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = rb.velocity;
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = movement;

    }




}
