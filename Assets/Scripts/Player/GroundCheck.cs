using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Player player;
    public Collider2D ball;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && Time.frameCount % 5 == 0) { player.isGrounded = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Player")) { player.isGrounded = true; }

        if (collision.CompareTag("Ball"))
        {
            player.isOnBall = true;
            ball = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Player")) { player.isGrounded = false; }

        if (collision.CompareTag("Ball")) { player.isOnBall = false; }
    }
}
