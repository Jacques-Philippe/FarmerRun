using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallGameOver : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(EndGameForPlayerFallen());
    }

    private bool PlayerHasFallen()
    {
        //the floor is at height 0, so if the player falls below -1 we can assume they fell
        return this.transform.position.y < -1;
    }

    private IEnumerator EndGameForPlayerFallen()
    {
        yield return new WaitUntil(() => !this.gameManager.IsGameOver && this.PlayerHasFallen());
        this.gameManager.EndGame();
    }
}
