using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScene : MonoBehaviour
{
    GameObject dinoMessenger;
    SendDinoIndex dinoIndex;

    [SerializeField] Player player1;
    [SerializeField] Player player2;

    int p1SpriteToLoad;
    int p2SpriteToLoad;

    [SerializeField] GameObject hat;

    private void Start()
    {
        //in case any sprite are active, deactivate them all so that only one is active later
        for (int i = 0; i < player1.playerSprites.Length; i++)
        {
            if (player1.playerSprites[i].gameObject.activeSelf == true)
                player1.playerSprites[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < player2.playerSprites.Length; i++)
        {
            if (player2.playerSprites[i].gameObject.activeSelf == true)
                player2.playerSprites[i].gameObject.SetActive(false);
        }
        GetDinoIndex();

        if (dinoIndex == null)
        {
            player1.playerSprites[0].gameObject.SetActive(true);
            player2.playerSprites[1].gameObject.SetActive(true);

            player1.animator = player1.playerSprites[0].GetComponent<Animator>();
            player2.animator = player2.playerSprites[1].GetComponent<Animator>();
        }

        if (p1SpriteToLoad == p2SpriteToLoad) { hat.SetActive(true); }
        else { hat.SetActive(false); }
    }

    void GetDinoIndex()
    {
        dinoMessenger = GameObject.Find("DontDestroy");
        if (dinoMessenger == null) { return; }
        dinoIndex = dinoMessenger.GetComponent<SendDinoIndex>();

        p1SpriteToLoad = dinoIndex.player1Dino;
        p2SpriteToLoad = dinoIndex.player2Dino;

        player1.playerSprites[p1SpriteToLoad].gameObject.SetActive(true);
        player2.playerSprites[p2SpriteToLoad].gameObject.SetActive(true);

        player1.animator = player1.playerSprites[p1SpriteToLoad].GetComponent<Animator>();
        player2.animator = player2.playerSprites[p2SpriteToLoad].GetComponent<Animator>();
    }
}
