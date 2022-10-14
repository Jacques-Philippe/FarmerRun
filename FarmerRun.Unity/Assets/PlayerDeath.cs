using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerDeath : MonoBehaviour
{
    private GameManager mGameManager;
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this.mGameManager = GameObject.FindObjectOfType<GameManager>();

        this.mAnimator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitUntil(() => this.mGameManager.IsGameOver);
        this.mAnimator.SetBool("Death_b", true);
    }
    
}
