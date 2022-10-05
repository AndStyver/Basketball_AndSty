using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hoop"))
        {
            transform.position = new(0, 0);
            HoopScript hoop = collision.GetComponent<HoopScript>();
            hoop.score++;
            hoop.UpdateScoreText();
        }
    }
}
