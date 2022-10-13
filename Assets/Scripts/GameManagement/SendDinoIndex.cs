using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDinoIndex : MonoBehaviour
{
    static SendDinoIndex indexInstance;

    public int player1Dino;
    public int player2Dino;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (indexInstance == null) { indexInstance = this; }
        else { Destroy(gameObject); }
    }
}
