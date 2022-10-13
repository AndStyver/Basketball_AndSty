using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    Rigidbody2D rbody;
    AudioSource audSource;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        audSource = GetComponent<AudioSource>();

        ResetVelocity();
    }

    public void ResetVelocity() { rbody.velocity = Vector3.zero; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hoop") && rbody.velocity.y < 0)
        {
            transform.position = new(0, 0);
            rbody.velocity = new(0, rbody.velocity.y);
            HoopScript hoop = collision.GetComponent<HoopScript>();
            hoop.PlaySound();
            hoop.score++;
            hoop.UpdateScoreText();
        }
    }
}
