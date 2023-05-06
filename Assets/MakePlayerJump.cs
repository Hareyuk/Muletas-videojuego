using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Penguin")
        {
            Rigidbody2D rbPlayer = collision.GetComponent<Rigidbody2D>();
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 20);
        }
    }
}
