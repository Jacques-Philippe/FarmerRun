using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    public bool IsGameOver { get => isGameOver; }


    public void EndGame()
    {
        if (!IsGameOver)
        {
            Debug.Log("Game over");
            this.isGameOver = true;
        }
    }

    public void Reset()
    {
        //Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
