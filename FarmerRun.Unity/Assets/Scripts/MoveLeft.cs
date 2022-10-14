using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    private GameManager mGameManager;

    private void Start()
    {
        this.mGameManager = GameObject.FindObjectOfType<GameManager>();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 movement = -Vector3.forward * speed * Time.fixedDeltaTime;
        yield return new WaitUntil(() =>
        {
            this.transform.Translate(movement, Space.World);
            return this.mGameManager.IsGameOver;
        });
    }
}
