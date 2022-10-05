using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { CreateEdges(); }

    void CreateEdges()
    {
        Camera cam = Camera.main;

        var bottomLeft = (Vector2)cam.ScreenToWorldPoint(new(0, 0));
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new(0, cam.pixelHeight));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new(cam.pixelWidth, cam.pixelHeight));
        var bottomRight = (Vector2)cam.ScreenToWorldPoint(new(cam.pixelWidth, 0));

        var edge = gameObject.AddComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edge.points = edgePoints;
    }
}

