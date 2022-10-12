using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Score received from Score manager, to be transmitted to ScoreReceiver
    /// </summary>
    [HideInInspector]
    public string Score;

    [SerializeField]
    private GameObject GameUIPrefab;

    [SerializeField]
    private GameObject GameOverUIPrefab;

    private GameObject gameUI;
    private GameObject gameOverUI;

    private GameManager gameManager;
    private ScoreReceiver scoreReceiver;

    private void Awake()
    {

        this.gameUI = GameObject.Instantiate(GameUIPrefab);

        this.gameOverUI = GameObject.Instantiate(GameOverUIPrefab);
        this.gameOverUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();

        this.scoreReceiver = this.gameUI.transform.GetComponentInChildren<ScoreReceiver>();

        StartCoroutine("DisplayUI");
    }

    private IEnumerator DisplayUI()
    {
        yield return new WaitUntil(() => {
            DisplayGameUI();
            return gameManager.IsGameOver;
        });
        RemoveGameUI();
        DisplayGameOverUI();
    }

    private void DisplayGameUI()
    {
        //Debug.Log($"Displaying game UI with score {Score}");
        this.scoreReceiver.Score = this.Score;
    }

    private void RemoveGameUI()
    {
        this.gameUI.SetActive(false);
        
    }

    private void DisplayGameOverUI()
    {
        //Debug.Log($"Displaying game over UI with score {Score}");
        var receiver = this.gameOverUI.transform.GetComponentInChildren<ScoreReceiver>();
        receiver.Score = this.Score;
        this.gameOverUI.SetActive(true);
    }

}
