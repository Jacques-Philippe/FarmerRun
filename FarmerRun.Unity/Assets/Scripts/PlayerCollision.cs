using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool otherIsObstacle = collision.gameObject.GetComponent<MoveLeft>() != null;
        if (otherIsObstacle)
        {
            Debug.Log("Player collided with an obstacle");
            gameManager.EndGame();
        }
    }
}
