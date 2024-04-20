using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom_Movement : MonoBehaviour
{
    // Movement
    public float enemyMovementSpeed = 1.5f;

    // Welke kant
    public bool facingLeft;

    // Ground layer
    private LayerMask groundLayer;

    // Components
    private Rigidbody2D rbEnemy;
    private Animator animEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<Animator>();

        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animEnemy.SetBool("isRunning", true);

        if (facingLeft)
        {
            rbEnemy.velocity = new Vector2(enemyMovementSpeed, rbEnemy.velocity.y);
        }
        else
        {
            rbEnemy.velocity = new Vector2(-enemyMovementSpeed, rbEnemy.velocity.y);
        }

        // Raycast voor randen te detecteren.
        RaycastHit2D Grounded = Physics2D.Raycast(transform.position + new Vector3(-0.07f * transform.localScale.x, -0.1f), Vector2.down, 0.8f, groundLayer);
        Debug.DrawRay(transform.position + new Vector3(-0.07f * transform.localScale.x, -0.1f), Vector2.down * 0.8f, Color.red);
        if (!Grounded)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingLeft = !facingLeft;
        }
    }
}
