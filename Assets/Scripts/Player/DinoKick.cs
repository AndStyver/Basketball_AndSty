using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoKick : MonoBehaviour
{
    Player player;

    private void Awake() { player = GetComponentInParent<Player>(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Rigidbody2D ballRBody = collision.gameObject.GetComponent<Rigidbody2D>();
            ballRBody.velocity = Vector3.zero;
            ballRBody.AddForce(new(player.kickPower / 10, -player.kickPower), ForceMode2D.Impulse);
            this.gameObject.SetActive(false);
        }
    }
}
