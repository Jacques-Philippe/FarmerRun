using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private float incrementRate = 1.0f;

    private GameManager gameManager;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Increment rate {incrementRate}");

        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.uiManager = GameObject.FindObjectOfType<UIManager>();
        StartCoroutine("TrackScore");
    }

    private IEnumerator TrackScore()
    {
        yield return new WaitUntil(() =>
        {
            this.score += (int)incrementRate;
            this.uiManager.Score = $"{this.score}";
            //Debug.Log($"Set UI manager score to {this.score}");

            return this.gameManager.IsGameOver;
        });
    }
}
