using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float vel;
    public float jumpForce;

    public GameObject GroundCheck;
    private GroundCheck GroundCheckScript;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GroundCheckScript = GroundCheck.GetComponent<GroundCheck>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Movimento horizontal
        if (rb2d.velocity.magnitude < 5)
        {
            rb2d.velocity += new Vector2(vel, 0) * horizontalInput * Time.deltaTime;
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheckScript.isOnGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
}