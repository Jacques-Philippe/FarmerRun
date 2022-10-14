using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerDeath : MonoBehaviour
{
    /// <summary>
    /// The dirt particles kicked up by the player's boots
    /// </summary>
    [SerializeField]
    private ParticleSystem mBootDirt;

    /// <summary>
    /// A reference to our game manager so we can keep track of whether or not the game is over
    /// </summary>
    private GameManager mGameManager;
    /// <summary>
    /// A reference to the player's animator to be able to update the animator state on death
    /// </summary>
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        this.mGameManager = GameObject.FindObjectOfType<GameManager>();

        this.mAnimator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(Die());
    }

    /// <summary>
    /// The function to run when the player dies, on game over
    /// </summary>
    /// <returns></returns>
    private IEnumerator Die()
    {
        yield return new WaitUntil(() => this.mGameManager.IsGameOver);
        this.mBootDirt.Stop();
        this.mAnimator.SetBool("Death_b", true);
        this.mAnimator.SetInteger("DeathType_int", 1);
        
        //to move the player away from the fence
        Vector3 displacement = -Vector3.forward * 1.0f;
        this.transform.position += displacement;
    }
    
}
