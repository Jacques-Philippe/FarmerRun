using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The magnitude of the force by which the player jumps
    /// </summary>
    public float upwardsForceMagnitude;
    
    [SerializeField]
    private ParticleSystem mDirtParticleSystem;

    private Rigidbody rigidBody;

    private Animator animator;

    private PlayerAudio playerAudio;

    /// <summary>
    /// whether or not the player is currently jumping (includes falling)
    /// </summary>
    public bool isJumping { get; private set; }

    private GameManager mGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        this.mGameManager = GameObject.FindObjectOfType<GameManager>();
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.animator = this.GetComponent<Animator>();

        this.playerAudio = this.GetComponent<PlayerAudio>();


        this.isJumping = false;
    }

    public void Jump()
    {
        this.rigidBody.AddForce(this.transform.up * this.upwardsForceMagnitude, ForceMode.Impulse);
        this.isJumping = true;
        this.animator.SetTrigger("Jump_trig");
        this.playerAudio.PlayJumpSound();
        this.mDirtParticleSystem.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        bool otherIsFloor = other.gameObject.tag == "Floor";
        bool otherIsObstacle = other.gameObject.tag == "Obstacle";
        if (otherIsFloor)
        {
            this.isJumping = false;
            this.mDirtParticleSystem.Play();
        }
        else if (otherIsObstacle && !this.mGameManager.IsGameOver)
        {
            Debug.Log("Player collided with obstacle.");
            this.mGameManager.EndGame();
        }
    }

}
